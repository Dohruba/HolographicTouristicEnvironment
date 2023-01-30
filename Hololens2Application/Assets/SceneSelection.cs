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
    [PunRPC]
    public void SelectScene(string city)
    {
        Debug.Log("Selected: " + city);
        if (isProyectorController)
        {
            Debug.Log("Changing scene");
            //SceneManager.LoadScene(city.ToString(), LoadSceneMode.Single);
        }
    }
}
