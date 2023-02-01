using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCityController : MonoBehaviour, IMiniCityController
{
    [SerializeField]
    private bool isInitialized = false;
    [SerializeField]
    private GameObject instantiator;
    public void InstantiateRoomOnScan()
    {
        if (!isInitialized)
        {
            instantiator.GetComponent<QuickInstantiate>().Instantiate();
            isInitialized = true;
            Debug.Log("Initialized.");
        }
    }
}
