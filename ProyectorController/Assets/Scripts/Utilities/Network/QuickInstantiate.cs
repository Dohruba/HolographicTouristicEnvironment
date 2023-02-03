using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private Transform positionReference;
    private void Awake()
    {
       // Instantiate();
        
    }
    private void OnEnable()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        SetPositionReference();
        Vector3 pos = SceneSelection.InstantiatePosition;
        MasterManager.NetworkInstantiate(_prefab, pos, Quaternion.identity);
    }

    public void SetPositionReference()
    {
        try
        {
            positionReference = GameObject.FindGameObjectWithTag("MiniRoom").transform;
        }
        catch (NullReferenceException e)
        {
            Debug.Log("MiniRoom not yet instantiated");
        }
    }
}
