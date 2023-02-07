using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCMesenger : MonoBehaviour
{
    [SerializeField]
    private GameObject _InformationSender;
    public void OnRoomInstantiated()
    {
        PhotonView.Get(_InformationSender).RPC("RoomInitalized", RpcTarget.All);
    }
}
