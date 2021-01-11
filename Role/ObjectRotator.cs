using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;  

public class ObjectRotator : MonoBehaviour
{
    private InputDeviceCharacteristics controllerCharacteristics;
    private InputDevice targetDevice;
    public float speed;
    public GameObject currentObjectSpawned;
   


    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        targetDevice = devices[0];
    }

    private void Update()
    {
        if(currentObjectSpawned != null)
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis,out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        {
            float rotationAmount = primary2DAxisValue.x * speed * Time.deltaTime;

            currentObjectSpawned.transform.Rotate(transform.rotation.eulerAngles.x, rotationAmount, transform.rotation.eulerAngles.z);
        }
    }
}
