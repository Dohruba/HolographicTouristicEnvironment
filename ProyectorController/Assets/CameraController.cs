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
    private bool isCameraFound = false;

    // Update is called once per frame
    void Update()
    {
        if (!isCameraFound)
        {
            try
            {
                frontCamera = GameObject.FindGameObjectWithTag("FrontCamera").GetComponent<Camera>();
                if (frontCamera != null) isCameraFound = true;
            }catch(Exception e)
            {

            }
        }
        if (isCameraFound)
        {
            frontCamera.fieldOfView = _InfoReciever.GetComponent<InformationSender>().FoV;
        }
    }
}
