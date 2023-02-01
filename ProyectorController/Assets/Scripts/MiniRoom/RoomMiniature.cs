using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMiniature : MonoBehaviour
{
    private GameObject _infoReciever;
    private void Start()
    {
        Vector3 position = this.transform.position;
        _infoReciever = GameObject.FindGameObjectWithTag("InformationReciever");
        _infoReciever.GetComponent<SceneSelection>().InstantiatePosition = position;
        GameObject.FindGameObjectWithTag("RPCManager").GetComponent<RPCMesenger>().OnRoomInstantiated();
    }
}
