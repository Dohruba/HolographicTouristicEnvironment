using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCityController : MonoBehaviour, IMiniCityController
{
    [SerializeField]
    private bool isEnvironmentInitialized = false;
    [SerializeField]
    private GameObject miniRoomInstantiator;

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
}
