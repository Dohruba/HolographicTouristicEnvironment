using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCMessenger : MonoBehaviour
{
    public GameObject _InformationExchange;
    public void OnClickChangeScene(string city)
    {
        string position = GameObject.FindGameObjectWithTag("Anchor").transform.position.x.ToString() + " " +
            GameObject.FindGameObjectWithTag("Anchor").transform.position.y.ToString() + " " +
            GameObject.FindGameObjectWithTag("Anchor").transform.position.z.ToString() + " ";
        string rotation = Math.Ceiling((GameObject.FindGameObjectWithTag("Anchor").transform.rotation.eulerAngles.x)).ToString() + " " +
             Math.Ceiling(GameObject.FindGameObjectWithTag("Anchor").transform.rotation.eulerAngles.y).ToString() + " " +
              Math.Ceiling(GameObject.FindGameObjectWithTag("Anchor").transform.rotation.eulerAngles.z).ToString();
        city = city + " " + position + rotation;
        PhotonView.Get(_InformationExchange).RPC("SelectScene",RpcTarget.All, city);
    }

    //public void OnRoomInstantiated()
    //{
    //    PhotonView.Get(_InformationExchange).RPC("RoomInitalized", RpcTarget.All);
    //}
}
