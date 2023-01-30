using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public Vector3 spawnPosition;
    private bool isHeldInPlace = true;
    [SerializeField] private GameObject panelRenderer;

    private void OnEnable()
    {
        panelRenderer.SetActive(false);
        StartCoroutine(HoldBasePosition());
    }
    private void OnDisable()
    {
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
