using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    public GameObject uiPanel;

    [SerializeField]
    private XRNode xRNode = XRNode.LeftHand;
    private List<InputDevice> devices = new List<InputDevice>();

    private InputDevice device;

    private bool primaryButtonIsPressed;

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xRNode, devices);
        device = devices.FirstOrDefault();
    }

    void OnEnable()
    {
        if (!device.isValid)
        {
            Debug.Log("detected");
            GetDevice();
        }
    }


    // Update is called once per frame
    void Update()
    {
        bool primaryButtonValue = false;
        InputFeatureUsage<bool> primaryButtonUsage = CommonUsages.primaryButton;
        if (!device.isValid)
        {
            GetDevice();
        }
        if (device.TryGetFeatureValue(primaryButtonUsage, out primaryButtonValue) && primaryButtonValue && !primaryButtonIsPressed)
        {
            primaryButtonIsPressed = true;
            if (uiPanel.activeInHierarchy)
            {
                uiPanel.SetActive(false);
            }
            else
            {
                uiPanel.SetActive(true);
            }
        }
        else if (!primaryButtonValue && primaryButtonIsPressed)
        {
            primaryButtonIsPressed = false;
            Debug.Log("Primary released");
        }
    }
}
