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
public class Tutorial : MonoBehaviour
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

    internal State State { get => state; set => state = value; }

    void Start()
    {
        ChangingState(0);
    }

    public void ChangingState(int stateNumber)
    {
        state = state != State.HelpPrompt ? (State)stateNumber : State.End;

        _helpPropmtPrefab.SetActive(state == State.Interaction || state == State.HelpPrompt);
        _solverToMarker.SetActive(state == State.Scanning);
        _handMenuIndicator.SetActive(state == State.HandMenu);
        _handMenuPanels.SetActive(state == State.HandMenu);
    }

}
