using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class LeaveRoomMenu : MonoBehaviourPunCallbacks
{
    RoomsCanvases _roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvases) {
        _roomsCanvases = canvases;
    }
    public void OnClick_LeaveRoom()
    {
        _roomsCanvases.CreateOrJoinRoomCanvas.Show();
        _roomsCanvases.CurrentRoomCanvas.Hide();
        PhotonNetwork.LeaveRoom(true);
    }
}
