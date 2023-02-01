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
    }
}
