using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMiniCityController
{
    public void InstantiateMiniRoom();
    public void InitializeEnvironmentOnScan();
    public void ActivateRoomContent(bool activate);
}
