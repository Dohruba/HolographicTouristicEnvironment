using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSelection : MonoBehaviourPun
{
    [SerializeField]
    private bool isProyectorController;
    [SerializeField]
    private InstantiateUtility[] cityInstantiators;
    [SerializeField]
    private static Vector3 instantiatePosition;
    private static Quaternion rotation;

    public static Vector3 InstantiatePosition { get => instantiatePosition; set => instantiatePosition = value; }
    public static Quaternion Rotation { get => rotation; set => rotation = value; }

    [PunRPC]
    public void SelectScene(string city)
    {
        string[] message = city.Split(' ');
        int cityNumber = int.Parse(message[0]);
        InstantiatePosition = StringToPosition(message[1], message[2], message[3]);
        Rotation = StringToRotation(message[4], message[5], message[6]);
        InstantiateCity(cityNumber);
    }

    private Vector3 StringToPosition(string xString, string yString, string zString)
    {
        float x = float.Parse(xString);
        float y = float.Parse(yString);
        float z = float.Parse(zString);
        return new Vector3(x, y, z);
    }
    private Quaternion StringToRotation(string xString, string yString, string zString)
    {
        float x = float.Parse(xString);
        float y = float.Parse(yString);
        float z = float.Parse(zString);
        return Quaternion.Euler(x, y, z);
    }

    private void InstantiateCity(int cityNumber)
    {
        if (isProyectorController)
        {
            GameObject[] buildings = GameObject.FindGameObjectsWithTag("City");
            foreach (GameObject building in buildings)
            {
                PhotonNetwork.Destroy(building);
            }
            cityInstantiators[cityNumber].Instantiate();
            GameObject.FindGameObjectWithTag("City").transform.rotation = Rotation;
        }
    }
}
