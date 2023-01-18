using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoomCanvas createOrJoinRoomCanvas;
    [SerializeField]
    private CurrentRoomCanvas currentRoomCanvas;

    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas { get => createOrJoinRoomCanvas;}
    public CurrentRoomCanvas CurrentRoomCanvas { get => currentRoomCanvas;}

    private void Awake()
    {
        FirstInitialize();
    }
    private void FirstInitialize()
    {
        CreateOrJoinRoomCanvas.Initialize(this);
        CurrentRoomCanvas.Initialize(this);
    }
}
