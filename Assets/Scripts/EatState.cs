using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class EatState : State
{
    [HideInInspector] public GameObject[] foodList;
    public string[] foodTagArray;
    public float RestoresEat = 0.6f;
    public float EatDistance = 1f;
    public float maxSearchDistance = 50f;
    [HideInInspector] public State NoApplesState;
    [HideInInspector] Transform targetApple;
    float minRange;

    public override void Init()
    {
        for (int i = 0; i < foodTagArray.Length; i++)
        {
            Debug.Log(foodTagArray.Length);
            if (!GameObject.FindGameObjectWithTag(foodTagArray[i]))
            {

            }
            else
            {
                foodList = GameObject.FindGameObjectsWithTag(foodTagArray[i]);
                if (targetApple == null)
                {
                    minRange = Vector3.Distance(Character.heroTransform.position, foodList[0].transform.position);
                    targetApple = foodList[0].transform;
                }

                for (int j = 1; j < foodList.Length; j++)
                {
                    if (minRange > Vector3.Distance(Character.heroTransform.position, foodList[j].transform.position))
                    {
                        minRange = Vector3.Distance(Character.heroTransform.position, foodList[j].transform.position);
                        targetApple = foodList[j].transform;
                    }
                }

            }
        }
        foodList = null;
    }

    public override void Run()
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

            if (distance > EatDistance && distance < maxSearchDistance)
            {
                if (distance < maxSearchDistance)
                {
                    Character.MoveTo(targetApple.position);
                }
                else
                {
                    Character.SetState(NoApplesState);
                }
            }
            else
            {
                try
                {
                    EatFood();
                }
                catch
                {
                    Character.ChoiceState();
                }
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
