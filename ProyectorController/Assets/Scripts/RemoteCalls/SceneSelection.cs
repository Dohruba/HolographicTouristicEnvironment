using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum cities
{
    city1,city2,city3,city4
}

public class SceneSelection : MonoBehaviourPun
{
    [SerializeField]
    private bool isProyectorController;
    [SerializeField]
    private GameObject[] cities;
    [SerializeField]
    private static Vector3 instantiatePosition;

    public GameObject[] Cities { get => cities; set => cities = value; }
    public static Vector3 InstantiatePosition { get => instantiatePosition; set => instantiatePosition = value; }

    [PunRPC]
    public void SelectScene(string city)
    {
        int cityNumber = int.Parse(city);
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        Debug.Log("Selected: " + city);
        foreach(GameObject building in buildings)
        {
            PhotonNetwork.Destroy(building);
        }
        if (isProyectorController)
        {
            Debug.Log("Changing scene");
            foreach(GameObject place in cities)
            {
                place.SetActive(false);
            }
            if(cities.Length > 0) cities[cityNumber].SetActive(true);

        }
    }
}
