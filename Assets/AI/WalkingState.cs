
using UnityEngine;

public class WalkingState : IDogState
{
    private StatePatternDog statePatternDog;

    public WalkingState(StatePatternDog statePatternDog)
    {
        this.statePatternDog = statePatternDog;
    }

    public void HandleMeClick(RaycastHit hit)
    {
    
    }

    public void HandleRoomClick(RaycastHit hit)
    {

    }

    public void ToRunningState()
    {
       statePatternDog.currentState = statePatternDog.runningState;
    }

    public void ToSleepState()
    {
        statePatternDog.currentState = statePatternDog.sleepingState;
    }

    public void ToWalkingState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void UpdateState()
    {
       
    }
}