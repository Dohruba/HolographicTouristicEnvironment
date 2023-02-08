using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtility : MonoBehaviour, IInstantiateUtilityMaster
{
    [SerializeField]
    private GameObject _prefab;
    //[SerializeField]
    //private Transform positionReference;
    private void OnEnable()
    {
        Instantiate();
    }

    public void Instantiate()
    {
        Vector3 pos = SceneSelection.InstantiatePosition;
        Quaternion rot = SceneSelection.rotation;
        Debug.Log("Instantiated in: -------------" + pos.ToString());
        MasterManager.NetworkInstantiate(_prefab, pos, rot);
    }
}
