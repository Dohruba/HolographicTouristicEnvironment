using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentToggler : MonoBehaviour
{
    public void OnTouchToggle(GameObject gameObject)
    {
        bool isActive = gameObject.activeSelf;
        gameObject.SetActive(!isActive);
    }
}
