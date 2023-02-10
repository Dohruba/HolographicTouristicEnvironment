using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouristicSceneController : MonoBehaviour, ITouristicSceneController
{
    [SerializeField]
    private bool isEnvironmentInitialized = false;
    //[SerializeField]
    //private GameObject miniRoomInstantiator;
    [SerializeField]
    private GameObject[] roomObjects;
    [SerializeField]
    private static GameObject[] dialogPanels;
    private bool initialRelocation = true;

    //private bool hasAnchorBeenFound = false;

    private void Start()
    {
        ActivateRoomContent(false);
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

    public void RelocateMiniRoom()
    {
        GameObject.FindGameObjectWithTag("Miniroom").GetComponent<RoomMiniatureController>().TakePosition();
    }
    public void InitialRoomRelocation()
    {
        if (initialRelocation)
        {
            initialRelocation = false;
            RelocateMiniRoom();
        }
    }
}
