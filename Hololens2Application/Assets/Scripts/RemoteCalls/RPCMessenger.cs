using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCMessenger : MonoBehaviour
{
    public GameObject _InformationExchange;
    private Transform _Anchor;
    public void OnClickChangeScene(string city)
    {
        _Anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
        string position =   _Anchor.position.x.ToString() + " " +
                            _Anchor.position.y.ToString() + " " +
                            _Anchor.position.z.ToString() + " ";
        string rotation =   Math.Ceiling(_Anchor.rotation.eulerAngles.x).ToString() + " " +
                            Math.Ceiling(_Anchor.rotation.eulerAngles.y).ToString() + " " +
                            Math.Ceiling(_Anchor.rotation.eulerAngles.z).ToString();
        city = city + " " + position + rotation;
        PhotonView.Get(_InformationExchange).RPC("SelectScene",RpcTarget.All, city);
    }



    //public void OnRoomInstantiated()
    //{
    //    PhotonView.Get(_InformationExchange).RPC("RoomInitalized", RpcTarget.All);
    //}
}
