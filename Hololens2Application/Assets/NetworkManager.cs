using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public bool Send = false;
    public GameObject _InformationSender;
    public float test = 0;
    void Update()
    {
        if (Send)
        {
            Send = false;
            PhotonView.Get(_InformationSender).RPC("SendFoV", RpcTarget.All, test.ToString());
        }
    }
}
