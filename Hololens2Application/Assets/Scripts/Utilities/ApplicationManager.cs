using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject AnchorParent;
    public void CloseAppliacation()
    {
        Application.Quit();
    }
    private void Start()
    {
        StartCoroutine(CallSpatialAnchors());
    }

    private IEnumerator CallSpatialAnchors()
    {
        AnchorModuleScript anchor = AnchorParent.GetComponent<AnchorModuleScript>();
        yield return new WaitForSeconds(4);
        anchor.StartAzureSession();
        yield return new WaitForSeconds(4);
        anchor.GetAzureAnchorIdFromDisk();
        yield return new WaitForSeconds(4);
        anchor.FindAzureAnchor();
        yield return new WaitForSeconds(4);
        anchor.StopAzureSession();
        gameObject.GetComponent<MiniCityController>().AnchorWasFound();
    }



}
