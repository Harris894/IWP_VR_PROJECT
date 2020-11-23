﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovementCustom : MonoBehaviour
{
    public float speed = 1;
    public XRNode inputSource;
    public float gravity = -9.81f;

    public float additionalHeight = 0.20f;
    public LayerMask groundLayer;
    private float fallingSpeed;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;
    
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadseat();
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction*Time.fixedDeltaTime);

        //gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
            fallingSpeed = 0;
        else
            fallingSpeed += gravity * Time.fixedDeltaTime;
        
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    void CapsuleFollowHeadseat()
    {
        character.height = rig.cameraInRigSpaceHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float raylength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, raylength, groundLayer);
        return hasHit;
    }
}