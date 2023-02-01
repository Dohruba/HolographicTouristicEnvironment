using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private bool onAwake = false;
    [SerializeField]
    private bool isRoomInitialized = false;
    [SerializeField]
    private NetworkManager networkManager;

    public bool IsRoomInitialized { get => isRoomInitialized; set => isRoomInitialized = value; }

    private void Awake()
    {
        if(onAwake) Instantiate();
    }

    public void Instantiate()
    {
        Vector3 pos = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z);

        MasterManager.NetworkInstantiate(_prefab, pos, Quaternion.identity);
        networkManager.OnRoomInstantiated();
    }
    public void CheckToInstantiate()
    {
        if (!isRoomInitialized)
        {
            Instantiate();
        }
    }
}
