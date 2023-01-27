using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnNearFlash : MonoBehaviour
{
    [SerializeField]
    private GameObject[] userParts;
    [SerializeField]
    private Material material1;
    [SerializeField]
    private Material material2;
    [SerializeField]
    private GameObject model;


    private void Start()
    {
        //Lookup user parts
        StartCoroutine(OnNearFlashMaterial());
    }

    private IEnumerator OnNearFlashMaterial()
    {
        while (true)//User close
        {
            model.GetComponent<Renderer>().material = material2;
            yield return new WaitForSecondsRealtime(1);
            model.GetComponent<Renderer>().material = material1;
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
