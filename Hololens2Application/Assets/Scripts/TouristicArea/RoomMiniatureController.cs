using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMiniatureController : MonoBehaviour, IRoomMiniatureController
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
        SetBoundControls();
    }

    public void SetBoundControls()
    {
        boundsControl.ScaleHandlesConfig.ShowScaleHandles = false;
        boundsControl.RotationHandlesConfig.ShowHandleForX = false;
        boundsControl.RotationHandlesConfig.ShowHandleForZ = false;
    }
    public void TakePosition()
    {
        transform.position = GameObject.FindGameObjectWithTag("Anchor").transform.position;
    }
}