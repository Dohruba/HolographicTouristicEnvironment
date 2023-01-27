using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public bool Send = false;
    public GameObject _InformationSender;
    public float _FoVMessage = 0;
    [SerializeField]
    private ProyectionPlaceholder _ProyectionPlaceholder;
    void Update()
    {
        
        try
        {
            _FoVMessage = _ProyectionPlaceholder.getFoV();
            PhotonView.Get(_InformationSender).RPC("SendFoV", RpcTarget.All, _FoVMessage.ToString());
        }
        catch (Exception e)
        {

        }
    }
}
