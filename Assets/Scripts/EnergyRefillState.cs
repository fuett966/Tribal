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
    public GameObject [] bedList ;

    public override void Init()
    {
        if (!GameObject.FindGameObjectWithTag("Bed"))
        {
            return;
        }
        else
        {
            bedList = GameObject.FindGameObjectsWithTag("Bed");
            float minRange = Vector3.Distance(Character.heroTransform.position, bedList[0].transform.position);
            targetBed = bedList[0].transform;
            for (int i = 1;i < bedList.Length;i++)
            {
                if (minRange > Vector3.Distance(Character.heroTransform.position, bedList[i].transform.position))
                {
                    minRange = Vector3.Distance(Character.heroTransform.position, bedList[i].transform.position);
                    targetBed = bedList[i].transform;
                }
            }
            bedList = null;
        }
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
        if ((targetBed.position - Character.transform.position).magnitude > 1f)
        {
            Character.MoveTo(targetBed.position);
        }
        else
        {
            lastCharPos = Character.transform.position;
            Character.transform.position = targetBed.position;
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
        Character.transform.position = lastCharPos;
        Character.Energy = 1f;
        IsFinished = true;
    }
}
