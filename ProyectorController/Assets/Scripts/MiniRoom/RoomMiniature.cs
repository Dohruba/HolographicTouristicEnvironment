using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMiniature : MonoBehaviour
{
    private void Start()
    {
        Vector3 position = this.transform.position;
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().InitalizeReferencePosition(position);
        GameObject.FindGameObjectWithTag("RPCManager").GetComponent<RPCMesenger>().OnRoomInstantiated();
    }
}
