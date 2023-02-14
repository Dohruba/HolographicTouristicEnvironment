using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTracker : MonoBehaviour
{
    public Vector3 cameraPos;
    public Quaternion cameraRot;
    private bool hasCameraBeenPlaced = false;
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Lobby"))
        {
            cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
            cameraRot = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
        }
        else
        {
            if (!hasCameraBeenPlaced)
            {
                hasCameraBeenPlaced = true;
                StartCoroutine(MoveCamera());
            }
        }
    }

    private IEnumerator MoveCamera()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (GameObject.FindGameObjectWithTag("MainCamera"))
            {
                GameObject.FindGameObjectWithTag("MainCamera").transform.position = cameraPos;
                GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = cameraRot;
                yield break;
            }
        }
    }
}
