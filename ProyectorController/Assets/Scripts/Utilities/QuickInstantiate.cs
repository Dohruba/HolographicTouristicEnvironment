using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour, IQuickInstantiateMaster
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

    public void Instantiate()
    {
        Vector3 pos = SceneSelection.InstantiatePosition;
        Quaternion rot = SceneSelection.rotation;
        Debug.Log("Instantiated in: -------------" + pos.ToString());
        MasterManager.NetworkInstantiate(_prefab, pos, rot);
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
