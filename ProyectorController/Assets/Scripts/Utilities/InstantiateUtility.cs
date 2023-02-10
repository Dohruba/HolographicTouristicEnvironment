using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtility : MonoBehaviour, IInstantiateUtilityMaster
{
    [SerializeField]
    private GameObject _prefab;
    public void Instantiate()
    {
        Vector3 pos = SceneSelection.InstantiatePosition;
        Quaternion rot = SceneSelection.Rotation;
        Debug.Log("Instantiated in: -------------" + pos.ToString());
        MasterManager.NetworkInstantiate(_prefab, pos, rot);
    }
}
