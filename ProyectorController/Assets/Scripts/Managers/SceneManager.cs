using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private InstantiateUtility MiniRoomInstantiator;

    private void Start()
    {
        StartCoroutine(InstantiateMiniRoom());
    }

    private IEnumerator InstantiateMiniRoom()
    {
        yield return new WaitForSeconds(3);
        MiniRoomInstantiator.Instantiate();
    }
}
