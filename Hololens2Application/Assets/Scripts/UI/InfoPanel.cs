using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public Vector3 spawnPosition;
    private bool isHeldInPlace = true;
    [SerializeField] private GameObject panelRenderer;
    [SerializeField] private GameObject interactionCue;
    private void OnEnable()
    {
        panelRenderer.SetActive(false);
        if(interactionCue != null)
        {
            interactionCue.SetActive(false);
        }
        StartCoroutine(HoldBasePosition());
    }
    private void OnDisable()
    {
        if (interactionCue != null)
        {
            interactionCue.SetActive(true);
        }
        StopAllCoroutines();
    }
    public void ReturnToSpawnPosition()
    {
        transform.localPosition = spawnPosition;
    }
    private IEnumerator HoldBasePosition()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        ReturnToSpawnPosition();
        while (isHeldInPlace)
        {
            ReturnToSpawnPosition();
            panelRenderer.SetActive(true);
            yield return new WaitForSeconds(30);
        }
    }
}
