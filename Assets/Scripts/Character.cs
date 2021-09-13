using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Initial Parameters")]
    public float Eat = 1f;
    public float Energy = 1f;

    public State StartState;
    public State EatState;
    public State EnergyState;
    public State RandomMoveState;
    [HideInInspector]public Transform heroTransform;
    // public Animator Animator;

    [Header("Actual state")]
    public State CurrentState;
    [Header("Hunger rate")]
    public float eatEndTime = 30f;
    [Header("Fatigue rate")]
    public float energyEndTime = 85f;

    void Start()
    {
        heroTransform = GetComponent<Transform>();
        SetState(StartState);

    }

    void Update()
    {
        Eat -= Time.deltaTime/eatEndTime;
        Energy -= Time.deltaTime / energyEndTime;

        if (!CurrentState.IsFinished)
        {
            CurrentState.Run();
        }
        else
        {
            if (Eat <= -1)
            {
                Destroy(this.gameObject);
            }
            else if (Eat <= 0.5f)
            {
                SetState(EatState);
            }
            else if (Energy <= 0.4f)
            {
                SetState(EnergyState);
            }
            else
            {
                SetState(RandomMoveState);
            }
        }
    }
    public void SetState (State state)
    {
        CurrentState = Instantiate(state);
        CurrentState.Character = this;
        CurrentState.Init();
    }
    public void MoveTo(Vector3 position)
    {
        position.y = transform.position.y;

        transform.position = Vector3.MoveTowards(current: transform.position ,target: position ,Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(from: transform.rotation ,to: Quaternion.LookRotation(position - transform.position),maxDegreesDelta:Time.deltaTime *120f );

    }
}
