using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;

    private RoomsCanvases _roomsCanvases;

    public LeaveRoomMenu LeaveRoomMenu { get => _leaveRoomMenu; private set => _leaveRoomMenu = value; }

    public void Initialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _playerListingsMenu.FirstInitialize(canvases);
        LeaveRoomMenu.FirstInitialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
