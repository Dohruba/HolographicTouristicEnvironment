using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationSender : MonoBehaviourPun
{
    [SerializeField]
    private float FoV = 0;


    [PunRPC]
    public void SendFoV(string foVAngle)
    {
        //Debug.Log(string.Format("FoV: {0}", foVAngle));
        FoV = float.Parse(foVAngle);
    }
}
