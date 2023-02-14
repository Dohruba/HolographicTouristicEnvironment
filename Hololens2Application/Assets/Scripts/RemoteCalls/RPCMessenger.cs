using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPCMessenger : MonoBehaviour
{
    public GameObject _InformationExchange;
    private Transform _Anchor;
    private string spacer = " ";
    public void OnClickChangeScene(string city)
    {
        _Anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
        string position = PositionToString(_Anchor.position);
        string rotation = RotationToString(_Anchor.rotation);
        city = city + spacer + position + spacer + rotation;
        Debug.Log(city);
        PhotonView.Get(_InformationExchange).RPC("SelectScene",RpcTarget.All, city);
    }

    private string PositionToString(Vector3 position)
    {
        string result = "";
        result += position.x.ToString() + spacer;
        result += position.y.ToString() + spacer;
        result += position.z.ToString();
        return result;
    }
    private string RotationToString(Quaternion rotation)
    {
        string result = "";
        result += rotation.eulerAngles.x.ToString() + spacer;
        result += rotation.eulerAngles.y.ToString() + spacer;
        result += rotation.eulerAngles.z.ToString();
        return result;
    }
}
