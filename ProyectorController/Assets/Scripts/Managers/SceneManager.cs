using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Vector3 referencePosition;
    private bool isInitialized = false;
    [SerializeField]
    private GameObject MiniRoomInstantiator;

    private void Start()
    {
        StartCoroutine(InstantiateMiniRoom());
    }
    public void InitalizeReferencePosition(Vector3 position)
    {
        if (!isInitialized)
        {
            referencePosition = position;
            SceneSelection.InstantiatePosition = position;
        }
    }

    private IEnumerator InstantiateMiniRoom()
    {
        yield return new WaitForSeconds(3);
        MiniRoomInstantiator.SetActive(true);
    }
}
