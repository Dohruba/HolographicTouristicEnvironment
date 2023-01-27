using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectionPlaceholder : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private Vector3 cameraPosition;
    [SerializeField]
    private bool isLookingForward;

    [Space]
    [Header("Proyection surface")]

    [SerializeField]
    private GameObject surface;
    [SerializeField]
    private Vector2 proyectionDimensions;
    [SerializeField] 
    private Vector3 surfaceRight;
    [SerializeField]
    private Vector3 surfaceLeft;

    [Space]
    [Header("Values")]
    [SerializeField]
    private float distanceCameraToProyection;
    [SerializeField]
    private float FoV;
    [SerializeField]
    private Quaternion lookingAngle;

    public float getFoV()
    {
        return FoV;
    }
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        float offset = proyectionDimensions.x/2;
        if (isLookingForward)
        {
            surfaceRight = surface.transform.position + new Vector3(offset, 0, 0);
            surfaceLeft = surface.transform.position - new Vector3(offset, 0, 0);
        }
        else
        { 
            surfaceRight = surface.transform.position - new Vector3(0, 0, offset);
            surfaceLeft = surface.transform.position + new Vector3(0, 0, offset);
        }
        
    }
    private void Update()
    {
        cameraPosition = camera.transform.position;
        FoV = Vector3.Angle((surfaceRight-cameraPosition),(surfaceLeft-cameraPosition));
    }
}

/*
 1. FoV
 2. Rotation of camera
 */