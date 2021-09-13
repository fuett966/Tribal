using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EatState : State
{
    public GameObject [] foodList ;
    public float RestoresEat = 0.6f;
    public float EatDistance = 1f;
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
            foodList = GameObject.FindGameObjectsWithTag("Apple");
            float minRange = Vector3.Distance(Character.heroTransform.position, foodList[0].transform.position);
            targetApple = foodList[0].transform;
            for (int i = 1;i < foodList.Length;i++)
            {
                if (minRange > Vector3.Distance(Character.heroTransform.position, foodList[i].transform.position))
                {
                    minRange = Vector3.Distance(Character.heroTransform.position, foodList[i].transform.position);
                    targetApple = foodList[i].transform;
                }
            }
            foodList = null;
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
        try
        {
            var distance = (targetApple.position - Character.transform.position).magnitude;

            if (distance >EatDistance)
            {
                Character.MoveTo(targetApple.position);
            }
            else
            {
                EatFood();
            }
            }
        catch
        {
            Character.SetState(NoApplesState);
        }
    }

    void EatFood()
    {
        Destroy(targetApple.gameObject);
        Character.Eat += RestoresEat;
        IsFinished = true;
    }
}
