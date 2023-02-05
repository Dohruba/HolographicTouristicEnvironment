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
    [SerializeField]
    private static GameObject[] dialogPanels;

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

    public void ActivateRoomContent(bool activate)
    {
        foreach(GameObject roomObject in roomObjects)
        {
            roomObject.SetActive(activate);
        }
    }
    public static void DeactivateOtherDialogPanels(GameObject dialog)
    {
        dialogPanels = GameObject.FindGameObjectsWithTag("DialogPanel");
        foreach (GameObject dialogPanel in dialogPanels)
        {
            if (dialog == dialogPanel) continue;
            dialogPanel.SetActive(false);
        }
    }
}
