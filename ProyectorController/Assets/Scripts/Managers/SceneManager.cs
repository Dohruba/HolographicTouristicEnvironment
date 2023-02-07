using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Vector3 referencePosition;
    private bool isInitialized = false;

    public void InitalizeReferencePosition(Vector3 position)
    {
        if (!isInitialized)
        {
            referencePosition = position;
            SceneSelection.InstantiatePosition = position;
        }
    }
}
