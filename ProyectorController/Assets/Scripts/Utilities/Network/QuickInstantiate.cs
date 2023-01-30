using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private void Awake()
    {
        Vector3 pos = new Vector3(transform.position.x,
            transform.position.y, 
            transform.position.z);

        MasterManager.NetworkInstantiate(_prefab, pos, Quaternion.identity );
        
    }
}
