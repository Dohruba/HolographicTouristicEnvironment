using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtility : MonoBehaviour,IInstantiateUtilityClient
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Vector3 position;
    [SerializeField]
    private GameObject reference;

    public void Instantiate()
    {
        if (reference != null) position = reference.transform.position;
        MasterManager.NetworkInstantiate(_prefab, position, Quaternion.identity);
    }
}
