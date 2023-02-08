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
    private GameObject[] cities;
    [PunRPC]
    public void SelectScene(string city)
    {
        int cityNumber = int.Parse(city.Split(' ')[0];
        Debug.Log("Selected: " + city);
        if (isProyectorController)
        {
            Debug.Log("Changing scene");
            PhotonNetwork.DestroyAll();
            foreach (GameObject place in cities)
            {
                place.SetActive(false);
            }
            if (cities.Length > 0) cities[cityNumber].SetActive(true);
        }
    }
}
