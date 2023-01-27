using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMovement : MonoBehaviourPun//, IPunObservable
{
    [SerializeField]
    private float _speed = 1f;

    //This works like update. It will be called an amount of times per second, according to the PhotonNetwork.SerializationRate (In master manager) 
    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)//Owner changing stuff
    //    {
    //        stream.SendNext(transform.position);
    //    } else if(stream.IsReading) //Is not owner
    //    {
    //        transform.position = (Vector3)stream.ReceiveNext();
    //    }
    //}

    private void Update()
    {
        if (base.photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            transform.position += (new Vector3(x, y, 0f))*_speed*Time.deltaTime;
        }
    }

    [PunRPC]
    public void TestSendInfo(string a)
    {
        Debug.Log(string.Format("FoV: {0}", a));
        _speed +=1;
    }

}
