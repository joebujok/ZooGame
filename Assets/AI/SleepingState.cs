
using UnityEngine;

public class SleepingState :IDogState
{
    private StatePatternDog statePatternDog;

    private float energyRecoverRate = 5f ;// per second
    private float energyNeededToWake;
    private bool sleeping;

    public SleepingState(StatePatternDog statePatternDog)
    {
        this.statePatternDog = statePatternDog;
    }

    public void ToRunningState()
    {
        statePatternDog.currentState = statePatternDog.runningState;
    }

    public void ToSleepState()
    {
        UnityEngine.Debug.Log("Can't transition to same state");
    }

    public void ToWalkingState()
    {
        statePatternDog.currentState = statePatternDog.walkingState;
    }

    public void UpdateState()
    {
        Sleep();
    }

    private void Sleep()
    {
        float currentEnergy = statePatternDog.energy.EnergyLevel;
        if (!sleeping) {
            energyNeededToWake = Random.Range(80f, 100f);
            Debug.Log("Going to sleep, will wake when energy is : " + energyNeededToWake);
            sleeping = true;
        }
        if (currentEnergy < energyNeededToWake)
        {
            statePatternDog.energy.EnergyLevel = Mathf.Min(currentEnergy + (energyRecoverRate * Time.deltaTime), 100);

        }
        else {
            Debug.Log("Awake now, energy level is : " + currentEnergy);
            sleeping = false;
            ToRunningState();
        }



    }

    public void HandleRoomClick(RaycastHit hit)
    {
        Debug.Log("do nothing, dog is sleeping");
    }

    public void HandleMeClick(RaycastHit hit)
    {

    }
}