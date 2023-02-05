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

    private void Start()
    {
        ActivateRoomContent(false);
    }
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

    public void ActivateRoomContent( bool activate)
    {
        foreach(GameObject roomObject in roomObjects)
        {
            roomObject.SetActive(activate);
        }
    }
}
