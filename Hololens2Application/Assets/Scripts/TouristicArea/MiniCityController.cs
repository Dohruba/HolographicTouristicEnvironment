using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCityController : MonoBehaviour, IMiniCityController
{
    [SerializeField]
    private bool isEnvironmentInitialized = false;
    [SerializeField]
    private GameObject miniRoomInstantiator;
    public void InstantiateRoomOnScan()
    {
        if (!isEnvironmentInitialized)
        {
            miniRoomInstantiator.GetComponent<QuickInstantiate>().CheckToInstantiate();

            isEnvironmentInitialized = true;
            Debug.Log("Initialized.");
        }
    }
}
