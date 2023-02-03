using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnershipTransfer : MonoBehaviourPun
{
    public void TransferOwnership()
    {
        base.photonView.RequestOwnership();
    }
}
