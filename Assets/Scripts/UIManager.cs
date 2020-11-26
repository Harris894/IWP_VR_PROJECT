using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public GameObject uiPanel;

    [SerializeField]
    private XRNode xRNode = XRNode.LeftHand;
    private List<InputDevice> devices = new List<InputDevice>();

    private InputDevice device;

    private bool primaryButtonIsPressed;
    private bool secondaryButtonIsPressed;



    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xRNode, devices);
        device = devices.FirstOrDefault();
    }

    void OnEnable()
    {
        if (!device.isValid)
        {
            Debug.Log("Not detected");
            GetDevice();
        }
    }


    // Update is called once per frame
    void Update()
    {
        // capturing primary button press and release
        bool primaryButtonValue = false;
        bool secondaryButtonValue = false;

        InputFeatureUsage<bool> primaryButtonUsage = CommonUsages.primaryButton;
        InputFeatureUsage<bool> secondaryButtonUsage = CommonUsages.secondaryButton;


        //Making sure the devices are registered.
        if (!device.isValid)
        {
            GetDevice();
        }


        if (device.TryGetFeatureValue(primaryButtonUsage, out primaryButtonValue) && primaryButtonValue && !primaryButtonIsPressed)
        {
            //If pressed, turn ui panel on or off
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

        if (device.TryGetFeatureValue(secondaryButtonUsage, out secondaryButtonValue) && secondaryButtonValue && !secondaryButtonIsPressed)
        {
            Debug.Log("StartListeningFromUIManager");
            secondaryButtonIsPressed = true;
        }
        else if (!secondaryButtonValue && secondaryButtonIsPressed)
        {
            secondaryButtonIsPressed = false;
        }



    }

    
}
