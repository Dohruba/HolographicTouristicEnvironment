using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject AnchorParent;
    [SerializeField]
    private TouristicSceneController localManager;
    public void CloseAppliacation()
    {
        Application.Quit();
    }
    private void Start()
    {
#if !UNITY_EDITOR
        StartCoroutine(CallSpatialAnchors());
#endif
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
        localManager.RelocateMiniRoomInstantly();

    }


    public void TestMoveCamera()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position += new Vector3(1, 0, 0);
    }



}
