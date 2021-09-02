using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnergyRefillState : State
{
    Transform targetBed;

    Vector3 lastCharPos;

    bool isSleepStarted;
    float sleepTimeLeft = 7f;

    public override void Init()
    {
        targetBed = GameObject.FindGameObjectWithTag("Bed").transform;
    }

    public override void Run(){
        if (IsFinished)
        {
            return;
        }
        if (!isSleepStarted)
        {
            MoveToBed();
        }
        else
        {
            DoSleep();
        }
    }
    void MoveToBed()
    {
        // var distance:float = (targetBed.position - Character.transform.position).magnitude;
        if ((targetBed.position - Character.transform.position).magnitude > 1f)
        {
            Character.MoveTo(targetBed.position);
        }
        else
        {
            lastCharPos = Character.transform.position;
            Character.transform.position = targetBed.position;

            // Character.Animator.Play(stateName:"Sleep");
            isSleepStarted = true;
        }
    }
    void DoSleep()
    {
        sleepTimeLeft -= Time.deltaTime;
        
        if(sleepTimeLeft>0)
        {
            return;
        }
        // Character.Animator.Play(stateName:"EndSleep");
        Character.transform.position = lastCharPos;
        Character.Energy = 1f;
        IsFinished = true;
    }
}
