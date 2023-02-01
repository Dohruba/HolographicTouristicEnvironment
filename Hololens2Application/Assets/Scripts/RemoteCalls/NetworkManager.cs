using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public bool Send = false;
    public GameObject _InformationSender;
    public string _FoVMessage;
    [SerializeField]
    private ProyectionPlaceholder _ProyectionPlaceholder1;
    [SerializeField]
    private ProyectionPlaceholder _ProyectionPlaceholder2;
    [SerializeField]
    private bool isMultiplayer = false;
    [SerializeField]
    private RoomInstancesController _RoomInstancesController;
    //void Update()
    //{
        
    //    try
    //    {
    //        _FoVMessage = _ProyectionPlaceholder1.getFoV().ToString() + " " + _ProyectionPlaceholder2.getFoV().ToString();
    //        if (!isMultiplayer)
    //        {
    //            PhotonView.Get(_InformationSender).RPC("SendFoV", RpcTarget.All, _FoVMessage.ToString());
    //        }   
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}

    public void OnClickChangeScene(string city)
    {
        PhotonView.Get(_InformationSender).RPC("SelectScene",RpcTarget.All, city);
    }

    public void OnRoomInstantiated()
    {
        PhotonView.Get(_RoomInstancesController).RPC("RoomInitalized", RpcTarget.All);
    }
}
