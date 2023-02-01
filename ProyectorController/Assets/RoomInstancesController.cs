using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInstancesController : MonoBehaviourPun
{
    private GameObject[] currentInstances;
    [SerializeField]
    private bool isRoomInitialized = false;

    public bool IsRoomInitialized { get => isRoomInitialized; set => isRoomInitialized = value; }

    [PunRPC]
    public void RoomInitalized()
    {
        isRoomInitialized = true;
    }
}
