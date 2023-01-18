using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnershipTransfer : MonoBehaviourPun
{
    private void OnMouseDown()
    {
        base.photonView.RequestOwnership();
    }
}
