using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Connecting to Photon.", this);
        //PhotonNetwork.SendRate = 20;
        //PhotonNetwork.SerializationRate = 10;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon.", this);
        Debug.Log("Nickname is: " + PhotonNetwork.LocalPlayer.NickName, this);
        if (!PhotonNetwork.InLobby) PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server. Reason: " + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }

}


