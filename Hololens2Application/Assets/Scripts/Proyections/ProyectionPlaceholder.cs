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
    private Vector3 surfaceTop;
    private Vector3 surfaceBottom;

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
        surfaceTop = surface.transform.position + new Vector3(0, proyectionDimensions.y / 2,0);
        surfaceBottom = surface.transform.position - new Vector3(0, proyectionDimensions.y / 2,0);
    }
    private void Update()
    {
        cameraPosition = camera.transform.position;
        FoV = Vector3.Angle((surfaceTop-cameraPosition),(surfaceBottom-cameraPosition));
        distanceCameraToProyection = Mathf.Abs(cameraPosition.z - surface.transform.position.z);

    }
}

/*
 1. FoV
 2. Rotation of camera
 */