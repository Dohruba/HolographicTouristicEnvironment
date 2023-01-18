using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI _text;
    //Referencing the Photon Player
    private Player _player;

    public Player Player { get => _player; private set => _player = value; }
    public bool Ready = false;

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        SetPlayerText(Player);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
        if(targetPlayer != null && targetPlayer == Player)
        {
            if (changedProps.ContainsKey("RandomNumber"))
            {
                SetPlayerText(targetPlayer);
            }
        }
    }

    private void SetPlayerText(Player player)
    {
        int result = -1;
        if (player.CustomProperties.ContainsKey("RandomNumber"))
        result = (int)player.CustomProperties["RandomNumber"];
        _text.text = result.ToString() + ", " + player.NickName;

    }
}
