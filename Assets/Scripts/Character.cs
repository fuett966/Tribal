using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [Header("Initial Parameters")]
    public float Eat = 1f;
    public float Energy = 1f;

    public State StartState;
    public State EatState;
    public State EnergyState;
    public State RandomMoveState;
    [HideInInspector] public Transform heroTransform;
    // public Animator Animator;

    [Header("Actual state")]
    public State CurrentState;
    [Header("Hunger rate")]
    public float eatEndTime = 30f;
    [Header("Fatigue rate")]
    public float energyEndTime = 85f;
    
    [Header("Food limit for death")]
    public float FoodDeathLimit = -1f;
    [Header("Food limit for state")]
    public float FoodLimit = 0.5f;
    [Header("Energy limit for state")]
    public float EnergyLimit = 0.4f;
    [HideInInspector]public NavMeshAgent agent;
    [HideInInspector]public NavMeshPath navMeshPath;

    void Start()
    {
        heroTransform = GetComponent<Transform>();
        SetState(StartState);
        agent = GetComponent<NavMeshAgent>();
        navMeshPath = new NavMeshPath();
    }

    void Update()
    {
        Eat -= Time.deltaTime / eatEndTime;
        Energy -= Time.deltaTime / energyEndTime;

        if (!CurrentState.IsFinished)
        {
            CurrentState.Run();
        }
        else
        {
            ChoiseState();
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
        Debug.Log(position);
        agent.SetDestination(position);
        Debug.Log(agent.destination);
    }

    public void ChoiseState()
    {
        if (Eat <= FoodDeathLimit)
        { 
            Destroy(this.gameObject);
        }
        else if (Eat <= FoodLimit)
        {
            SetState(EatState);
        }
        else if (Energy <= EnergyLimit)
        {
            SetState(EnergyState);
        }
        else
        {
            SetState(RandomMoveState);
        }
    }
}