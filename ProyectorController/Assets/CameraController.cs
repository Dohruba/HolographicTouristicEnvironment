using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject _InfoReciever;
    [SerializeField]
    private Camera frontCamera;
    [SerializeField]
    private Camera sideCamera;
    [SerializeField]
    private bool isCameraFound = false;

    private void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);
        // Display.displays[0] is the primary, default display and is always ON, so start at index 1.
        // Check if additional displays are available and activate each.

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isCameraFound)
        {
            try
            {
                frontCamera = GameObject.FindGameObjectWithTag("FrontCamera").GetComponent<Camera>();
                sideCamera = GameObject.FindGameObjectWithTag("SideCamera").GetComponent<Camera>();
                if (frontCamera != null && sideCamera!= null) isCameraFound = true;
            }catch(Exception e)
            {

            }
        }
        if (isCameraFound)
        {
            frontCamera.fieldOfView = _InfoReciever.GetComponent<InformationSender>().FoVDisplay1;
            sideCamera.fieldOfView = _InfoReciever.GetComponent<InformationSender>().FoVDisplay2;
        }
    }
}
