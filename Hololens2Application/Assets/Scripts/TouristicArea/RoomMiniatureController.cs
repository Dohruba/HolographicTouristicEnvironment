using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMiniatureController : MonoBehaviour
{
    [SerializeField]
    private BoundsControl boundsControl;
    private void Awake()
    {
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