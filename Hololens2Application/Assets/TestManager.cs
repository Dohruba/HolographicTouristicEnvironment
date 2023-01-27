using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public bool Send = false;
    public GameObject simpleObjectMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Send)
        {
            Send = false;
            PhotonView.Get(simpleObjectMovement).RPC("TestSendInfo", RpcTarget.All, "Chicken");
        }
    }
}
