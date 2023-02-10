using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Interaction = 0,
    Scanning = 1,
    HandMenu =2,
    End = 3,
    HelpPrompt = 4
}
public class TutorialController : MonoBehaviour
{
    [SerializeField]
    private GameObject _helpPropmtPrefab;
    [SerializeField]
    private GameObject _solverToMarker;
    [SerializeField]
    private GameObject _handMenuIndicator;
    [SerializeField]
    private GameObject _handMenuPanels;
    [SerializeField]
    private State state;
    private bool hasMarkerBeenScanned = false;
    private bool hasSelectedScene;

    internal State State { get => state; set => state = value; }

    void Start()
    {
        ChangeState(0);
    }

    public void ChangeState(int stateNumber)
    {
        state = IsStateHelpPrompt() ? State.End : (State)stateNumber;
        ActivateStateContent();
        CheckMarkerStatus();
    }

    private void ActivateStateContent()
    {
        _helpPropmtPrefab.SetActive(state == State.Interaction || state == State.HelpPrompt);
        _solverToMarker.SetActive(state == State.Scanning && !hasMarkerBeenScanned);
        _handMenuIndicator.SetActive(state == State.HandMenu && !hasSelectedScene);
        _handMenuPanels.SetActive(state == State.HandMenu);
    }

    private void CheckMarkerStatus()
    {
        if (state == State.Scanning && !hasMarkerBeenScanned)
            hasMarkerBeenScanned = true;
        if (state == State.HandMenu && !hasSelectedScene)
            hasSelectedScene = true;
    }
    private bool IsStateHelpPrompt()
    {
        return state == State.HelpPrompt;
    }
}
