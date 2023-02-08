using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour,IQuickInstantiateClient
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private bool onAwake = false;
    [SerializeField]
    private bool isRoomInitialized = false;
    [SerializeField]
    private NetworkManager networkManager;
    [SerializeField]
    private Vector3 position;
    [SerializeField]
    private GameObject reference;


    public bool IsRoomInitialized { get => isRoomInitialized; set => isRoomInitialized = value; }

    private void Awake()
    {
        if(onAwake) Instantiate();
    }

    public void Instantiate()
    {
        if (reference != null) position = reference.transform.position;
        //if (position == null) position = transform.position;
        Debug.Log(position);
        MasterManager.NetworkInstantiate(_prefab, position, Quaternion.identity);
        networkManager.OnRoomInstantiated();
    }
    public void CheckToInstantiate()
    {
        if (!isRoomInitialized)
        {
            isRoomInitialized = true;
            Instantiate();
        }
    }
}
