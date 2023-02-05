using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCityController : MonoBehaviour, IMiniCityController
{
    [SerializeField]
    private bool isEnvironmentInitialized = false;
    [SerializeField]
    private GameObject miniRoomInstantiator;
    [SerializeField]
    private GameObject[] roomObjects;

    public void InstantiateMiniRoom()
    {
        if (isEnvironmentInitialized)
        {
            miniRoomInstantiator.GetComponent<QuickInstantiate>().CheckToInstantiate();
            Debug.Log("Initialized.");
        }
    }
    public void InitializeEnvironmentOnScan()
    {
        isEnvironmentInitialized = true;
    }

    public void ActivateRoomContent()
    {
        foreach(GameObject roomObject in roomObjects)
        {
            roomObject.SetActive(true);
        }
    }
}
