using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;
    [SerializeField]
    private TextMeshProUGUI _readyUpText;

    private bool _ready = false;

    private RoomsCanvases _canvases;

    private List<PlayerListing> _listings = new List<PlayerListing>();

    public override void OnEnable()
    {

        base.OnEnable();
        SetReadyUp(false);
        GetCurrentRoomPlayers();
    }

    private void SetReadyUp(bool v)
    {
        _ready = v;
        _readyUpText.text = v ? "Ready" : "Not Ready";
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for(int i = 0; i < _listings.Count; i++)
        {
            Destroy(_listings[i].gameObject);
        }
        _listings.Clear();
    }

    internal void FirstInitialize(RoomsCanvases canvases)
    {
        _canvases = canvases;
    }

    private void AddPlayerListing(Player player)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if(index != -1)
        {
            _listings[index].SetPlayerInfo(player);
        }
        else
        {
            PlayerListing listing = Instantiate(_playerListing, _content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _listings.Add(listing);
            }
        }
    }
    private void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected) return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null) return;
        foreach(KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }

    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {

            for (int i = 0; i < _listings.Count; i++)
            {
                if (_listings[i].Player != PhotonNetwork.LocalPlayer)
                {
                    if (!_listings[i].Ready) return;
                }
            }

            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void OnClick_ReadyUp()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!_ready);


            //Cause of photonview, a photonview component has to be added to the gameobject containing this call
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, _ready);
        }
    }


    [PunRPC]
    //RPC methods can be called over the network
    private void RPC_ChangeReadyState(Player player, bool ready)
    {
        int index = _listings.FindIndex(x => x.Player == player);
        if (index != -1)
        {
            _listings[index].Ready = ready;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _canvases.CurrentRoomCanvas.LeaveRoomMenu.OnClick_LeaveRoom();
    }
}
