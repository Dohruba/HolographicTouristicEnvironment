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
        ActivateDisplays();
    }
    void Update()
    {
        //SetCameras();
    }

    /**
     * Activates all available displays, to be able to assign them Camera components.
     */
    private void ActivateDisplays() {
        int numberOfDisplays = Display.displays.Length;
        for (int i = 1; i < numberOfDisplays; i++)
        {
            Display.displays[i].Activate();
        }
    }
    ///**
    // * Try to find the camera components and assign them to their 
    // */
    //private void SetCameras()
    //{
    //    if (!isCameraFound)
    //    {
    //        try
    //        {
    //            frontCamera = GameObject.FindGameObjectWithTag("FrontCamera").GetComponent<Camera>();
    //            sideCamera = GameObject.FindGameObjectWithTag("SideCamera").GetComponent<Camera>();
    //            if (frontCamera != null && sideCamera != null) isCameraFound = true;
    //            Debug.Log("Cameras found and set.");
    //        }
    //        catch (Exception e)
    //        {
    //            Debug.Log("Cameras not yet found.");
    //        }
    //    }
    //}
}
