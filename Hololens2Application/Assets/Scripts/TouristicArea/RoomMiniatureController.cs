using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System;
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
        StartCoroutine(FindAnchorAndMove());
    }
    private IEnumerator FindAnchorAndMove()
    {
        yield return new WaitForSeconds(4);
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (GameObject.FindGameObjectWithTag("Anchor"))
            {
                MoveToAnchorInstantly();
                yield break;
            }
        }
    }

    public void MoveToAnchorInstantly()
    {
        try
        {
            transform.position = GameObject.FindGameObjectWithTag("Anchor").transform.position +
                    new Vector3(0, 0.3f, 0);
        }catch(NullReferenceException e)
        {
            TakePosition();
        }
    }
}