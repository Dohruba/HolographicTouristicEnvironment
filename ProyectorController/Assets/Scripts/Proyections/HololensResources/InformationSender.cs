using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationSender : MonoBehaviourPun
{
    [SerializeField]
    public float FoVDisplay1 = 0;
    [SerializeField]
    public float FoVDisplay2 = 0;


    [PunRPC]
    public void SendFoV(string foVAngle)
    {
        //Debug.Log(string.Format("FoV: {0}", foVAngle));
        string[] FoVs = foVAngle.Split(' ');
        FoVDisplay1 = float.Parse(FoVs[0]);
        FoVDisplay2 = float.Parse(FoVs[1]);

    }
}
