using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMiniatureController : MonoBehaviour
{
    [SerializeField]
    private ObjectManipulator objectManipulator;
    [SerializeField]
    private BoundsControl boundsControl;
    private bool isOutside = false;



    private void Awake()
    {
        objectManipulator = GetComponent<ObjectManipulator>();
        boundsControl = GetComponent<BoundsControl>();
    }
    private void Start()
    {
        GameObject[] roomConstraints = GameObject.FindGameObjectsWithTag("MiniRoomConstraint");

        boundsControl.ScaleHandlesConfig.ShowScaleHandles = false;
        boundsControl.RotationHandlesConfig.ShowHandleForX = false;
        boundsControl.RotationHandlesConfig.ShowHandleForZ = false;

    }
}