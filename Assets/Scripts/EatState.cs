using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EatState : State
{
    public float RestoresEat = 0.6f;
    public State NoApplesState;

    Transform targetApple;

    public override void Init()
    {
        if (!GameObject.FindGameObjectWithTag("Apple"))
        {
            Character.SetState(NoApplesState);
            return;
        }
        else
        {
            targetApple = GameObject.FindGameObjectWithTag("Apple").transform;
        }
    }

    public override void Run ()
    {
        if (IsFinished)
        {
            return;
        }
        MoveToApple();
    }
    void MoveToApple()
    {
        var distance = (targetApple.position - Character.transform.position).magnitude;

        if (distance >1f)
        {
            Character.MoveTo(targetApple.position);
        }
        else
        {
            Destroy(targetApple.gameObject);
            Character.Eat += RestoresEat;
            IsFinished = true;
        }
    }
}
