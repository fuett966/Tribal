using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RandomMoveState : State
{
    public float MaxDistance = 5f;

    Vector3 randomPosition;

    public override void Init()
    {
        var randomed = new Vector3(x:Random.Range(-MaxDistance,MaxDistance), Character.transform.position.y/2, z:Random.Range(-MaxDistance,MaxDistance));
        randomPosition = Character.transform.position + randomed;
    }
    public override void Run()
    {
        if ((randomPosition - Character.transform.position).magnitude>0.45f)
        {
            Character.MoveTo(randomPosition);
        }
        else
        {
            IsFinished = true;
        }
    }
}
