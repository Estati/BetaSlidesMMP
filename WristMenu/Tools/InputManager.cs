using UnityEngine;
using UnityEngine.XR;

public class InputManager : MonoBehaviour
{
    // i know ControllerInputPoller exixts, but i was told to red othe input system, so yeah :) -nick
    
    public static InputManager instance;

    public InputDevice leftDevice;
    public InputDevice rightDevice;

    public bool leftValid;
    public bool rightValid;

    public float leftTrigger;
    public float rightTrigger;
    public float leftGrip;
    public float rightGrip;

    public Vector2 leftJoystick;
    public Vector2 rightJoystick;

    public bool leftPrimary;
    public bool rightPrimary;
    public bool leftSecondary;
    public bool rightSecondary;
    public bool leftTriggerButton;
    public bool rightTriggerButton;


    void Awake()
    {
        instance = this;
        leftDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rightDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    void Update()
    {
        leftValid = leftDevice.isValid;
        rightValid = rightDevice.isValid;

        if (!leftValid || !rightValid)
        {
            leftDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            rightDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        }

        leftDevice.TryGetFeatureValue(CommonUsages.trigger, out leftTrigger);
        leftDevice.TryGetFeatureValue(CommonUsages.grip, out leftGrip);
        leftDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out leftJoystick);
        leftDevice.TryGetFeatureValue(CommonUsages.primaryButton, out leftPrimary);
        leftDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out leftSecondary);
        leftDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftTriggerButton);

        rightDevice.TryGetFeatureValue(CommonUsages.trigger, out rightTrigger);
        rightDevice.TryGetFeatureValue(CommonUsages.grip, out rightGrip);
        rightDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out rightJoystick);
        rightDevice.TryGetFeatureValue(CommonUsages.primaryButton, out rightPrimary);
        rightDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out rightSecondary);
        rightDevice.TryGetFeatureValue(CommonUsages.triggerButton, out rightTriggerButton);
    }
}