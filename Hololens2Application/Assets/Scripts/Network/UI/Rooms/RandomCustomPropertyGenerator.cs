using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    private ExitGames.Client.Photon.Hashtable _customProperty = new ExitGames.Client.Photon.Hashtable();

    private void SetCustomNumber()
    {
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);

        _customProperty["RandomNumber"] = result;
        PhotonNetwork.SetPlayerCustomProperties(_customProperty);
        //PhotonNetwork.LocalPlayer.CustomProperties = _customProperty;
    }
    public void OnClick_Button()
    {
        SetCustomNumber();
    }
}
