using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [Header("Initial Parameters")]
    public float tempHunger;
    public float tempEnergy;
    public State StartState;
    public EatState EatState;
    public EnergyRefillState EnergyState;
    public RandomMoveState RandomMoveState;

    [Header("Actual state")]
    [SerializeField]public State CurrentState; 
    private float hungerRate;
    private float energyLossRate;

    [Header("Food limit for death")]
    public float FoodDeathLimit = -10f;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public NavMeshPath navMeshPath;

    void Start()
    {

        tempHunger = EatState.hunger;
        tempEnergy = EnergyState.energy;

        hungerRate = EatState.hungerRate;
        energyLossRate = EnergyState.energyLossRate;

        agent = GetComponent<NavMeshAgent>();
        navMeshPath = new NavMeshPath();

        SetState(StartState);
    }

    void Update()
    {
        if (tempHunger > 0)
        {
            tempHunger -= Time.deltaTime * hungerRate;
        }
        if (tempEnergy > 0)
        {
            tempEnergy -= Time.deltaTime * energyLossRate;
        }
        
        if (!CurrentState.IsFinished)
        {
            CurrentState.Run();
        }
        else
        {
            ChoiceState();
        }
    }

    public void SetState(State state)
    {
        CurrentState = Instantiate(state);
        CurrentState.Character = this;
        CurrentState.Init();
    }

    public void MoveTo(Vector3 position)
    {
        // Debug.DrawLine(transform.position, position);
        agent.SetDestination(position);
    }

    public void ChoiceState()
    {
        // if (tempHunger <= FoodDeathLimit)
        // {
        //     Destroy(this.gameObject);
        // }
        if (tempHunger <= EatState.FoodLimitForState)
        {
            SetState(EatState);
        }
        else if (tempEnergy <= EnergyState.EnergyLimitForState)
        {
            SetState(EnergyState);
        }
        else
        {
            SetState(RandomMoveState);
        }
    }
}