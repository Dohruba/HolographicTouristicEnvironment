using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCityController : MonoBehaviour, IMiniCityController
{
    public void ToggleMiniCity(GameObject miniCity)
    {
        bool isActive = miniCity.gameObject.activeSelf;
        miniCity.SetActive(!isActive);
    }
}
