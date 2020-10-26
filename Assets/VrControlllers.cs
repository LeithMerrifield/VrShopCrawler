using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrControlllers : MonoBehaviour
{
    List<UnityEngine.XR.InputDevice> inputDevices = new List<UnityEngine.XR.InputDevice>();
    List<UnityEngine.XR.XRNodeState> inputNodes = new List<UnityEngine.XR.XRNodeState>();
    // 0 = Right hand, 1 = Left Hand
    public GameObject[] VrControllers;

    void Update()
    {
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.Controller,inputDevices);
        UnityEngine.XR.InputTracking.GetNodeStates(inputNodes);

        foreach (var device in inputNodes)
        {
            if(device.nodeType == UnityEngine.XR.XRNode.LeftHand)
            {
                Vector3 newPosition = Vector3.zero;
                Quaternion newRotation = Quaternion.identity;
                device.TryGetRotation(out newRotation);
                device.TryGetPosition(out newPosition);
                VrControllers[1].transform.localPosition = newPosition;
                VrControllers[1].transform.localRotation = newRotation;
            }
            else if(device.nodeType == UnityEngine.XR.XRNode.RightHand)
            {
                Vector3 newPosition = Vector3.zero;
                Quaternion newRotation = Quaternion.identity;
                device.TryGetRotation(out newRotation);
                device.TryGetPosition(out newPosition);
                VrControllers[0].transform.localPosition = newPosition;
                VrControllers[0].transform.localRotation = newRotation;
            }
        }
    }


}
