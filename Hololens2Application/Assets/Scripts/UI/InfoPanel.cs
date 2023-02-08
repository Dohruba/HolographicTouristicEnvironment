using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    private void OnEnable()
    {
        TouristicSceneController.DeactivateOtherDialogPanels(gameObject);
    }

}
