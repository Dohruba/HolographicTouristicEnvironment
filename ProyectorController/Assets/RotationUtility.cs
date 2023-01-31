using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationUtility : MonoBehaviour
{
    [SerializeField]
    private Quaternion rotation;
    [SerializeField]
    private bool rotate;
    private void OnEnable()
    {
        if(rotate) transform.rotation = rotation;
    }
}
