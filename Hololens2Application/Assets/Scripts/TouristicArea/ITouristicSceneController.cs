using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouristicSceneController
{
    public void InitializeEnvironmentOnScan();
    public void ActivateRoomContent(bool activate);
}
