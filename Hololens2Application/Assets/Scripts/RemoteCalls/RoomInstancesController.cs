using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInstancesController : MonoBehaviourPun
{
    [SerializeField]
    private GameObject roomInstantiator;

    [PunRPC]
    public void RoomInitalized()
    {
        roomInstantiator.GetComponent<QuickInstantiate>().IsRoomInitialized = true;
    }
}
