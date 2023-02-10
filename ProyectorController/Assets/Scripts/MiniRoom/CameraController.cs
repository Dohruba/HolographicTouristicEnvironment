using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Start()
    {
        ActivateDisplays();
    }
    /**
     * Activates all available displays, to be able to assign them Camera components.
     */
    private void ActivateDisplays() {
        int numberOfDisplays = Display.displays.Length;
        for (int i = 1; i < numberOfDisplays; i++)
        {
            Display.displays[i].Activate();
        }
    }
}
