using UnityEngine;
using System.Collections;

public class StatePatternDog : MonoBehaviour
{

    public float speed;
    public Energy energy;
    public Selection selection;
    



    [HideInInspector]
    public IDogState currentState;
    [HideInInspector]
    public WalkingState walkingState;
    [HideInInspector]
    public RunningState runningState;
    [HideInInspector]
    public SleepingState sleepingState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    // Use this for initialization
    void Start()
    {
        currentState = runningState;

    }
    void Awake()
    {
        walkingState = new WalkingState(this);
        runningState = new RunningState(this);
        sleepingState = new SleepingState(this);
        energy = GetComponent<Energy>();
        selection = GetComponent<Selection>();
        Debug.Log("my STARTING energy level is : " + energy.EnergyLevel);

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }
}
