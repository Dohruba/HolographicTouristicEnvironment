using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public GameObject _InformationExchange;
    public void OnClickChangeScene(string city)
    {
        PhotonView.Get(_InformationExchange).RPC("SelectScene",RpcTarget.All, city);
    }

    public void OnRoomInstantiated()
    {
        PhotonView.Get(_InformationExchange).RPC("RoomInitalized", RpcTarget.All);
    }
}
