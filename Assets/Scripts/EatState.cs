using UnityEngine;
[CreateAssetMenu]
public class EatState : State
{
    [HideInInspector]public GameObject [] foodList ;
    public float RestoresEat = 0.6f;
    public float EatDistance = 1f;
    [HideInInspector]public State NoApplesState;
    [HideInInspector]Transform targetApple;

    public override void Init()
    {
        if (!GameObject.FindGameObjectWithTag("Food"))
        {
            Character.SetState(NoApplesState);
            return;
        }
        else
        {
            foodList = GameObject.FindGameObjectsWithTag("Food");
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

            if (distance > EatDistance)
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
