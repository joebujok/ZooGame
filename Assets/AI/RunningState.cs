using UnityEngine;

public class RunningState : IDogState
{
    private StatePatternDog statePatternDog;

    private Vector3 targetDest;
    private bool hasReachedDestination = false;
 

    private float energyDeclineRate = 5;  // per second
    private float energyNeedToRun = 30;

    public RunningState(StatePatternDog statePatternDog)
    {
        this.statePatternDog = statePatternDog;
    }

    public void ToRunningState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToSleepState()
    {
        statePatternDog.currentState = statePatternDog.sleepingState;
    }

    public void ToWalkingState()
    {
        statePatternDog.currentState = statePatternDog.walkingState;
    }

    public void UpdateState()
    {
        Move();
    }

    private void Move()
    {
        statePatternDog.speed = 7;
        if (targetDest == null || hasReachedDestination == true)
        {

            hasReachedDestination = false;
            targetDest = new Vector3(Random.Range(-8.0f, 8.0f), 0.5f, Random.Range(-8.0f, 8.0f));
            Debug.Log("Now running towards : " + targetDest);
        }
        float step = statePatternDog.speed * Time.deltaTime;
        statePatternDog.speed = 1;

        statePatternDog.energy.EnergyLevel = Mathf.Max( statePatternDog.energy.EnergyLevel - (energyDeclineRate * Time.deltaTime),0);

        statePatternDog.transform.position = Vector3.MoveTowards(statePatternDog.transform.position, targetDest, step);
        if (statePatternDog.transform.position == targetDest)
        {
            hasReachedDestination = true;
            Debug.Log("I have reach my destination : " + statePatternDog.transform.position);
            Debug.Log("my current energy level is : " + statePatternDog.energy.EnergyLevel);

            //not enough energy to run any more after reaching dest
            if (statePatternDog.energy.EnergyLevel < energyNeedToRun) {
                ToSleepState();
            }
        }    

    }

    public void HandleRoomClick(RaycastHit hit)
    {
        // targetDest = hit.transform.position;
        if (statePatternDog.selection.selected) {
            targetDest = new Vector3(hit.point.x, 0.5f, hit.point.z);
        }

    }

    public void HandleMeClick(RaycastHit hit)
    {

    }
}