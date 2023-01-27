using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject InfoPanel;

    private void Start()
    {
        InfoPanel.SetActive(false);
    }
    public void OnTouchSchowInfo()
    {
        InfoPanel.SetActive(!InfoPanel.activeSelf);
    }
}
