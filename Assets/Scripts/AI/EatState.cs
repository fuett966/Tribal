using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu]
public class EatState : State
{
    [HideInInspector] private GameObject[] foodGameObjectsArray;
    public string[] foodTagArray;
    public float hunger = 100f;
    public float hungerRate = 1f;
    public float RestoresEat = 50f;
    public float eatDistance = 1f;
    public float maxSearchDistance = 25f;
    public float FoodLimitForState = 25f;
    private State NoFoodState;
    private Transform targetFood;
    private float minRange;
    NavMeshHit navMeshHit;
    Vector3 foodPosition;

    public override void Init()
    {
        NoFoodState = Character.RandomMoveState;
        SearchFood();
    }

    public override void Run()
    {
        // Debug.Log(targetFood);
        if (targetFood == null && minRange > maxSearchDistance)
        {
            Character.SetState(NoFoodState);
            IsFinished = true;
            Debug.Log("Bebra1");
        }
        if (IsFinished)
        {
            return;
        }
        else
        {
            MoveToFood();
        }
    }

    public void SearchFood()
    {
        foreach (string tag in foodTagArray)
        {
            if (GameObject.FindGameObjectWithTag(tag))
            {
                foodGameObjectsArray = GameObject.FindGameObjectsWithTag(tag);
                if (targetFood == null)
                {
                    minRange = Vector3.Distance(Character.transform.position, foodGameObjectsArray[0].transform.position);
                    targetFood = foodGameObjectsArray[0].transform;
                }

                foreach (GameObject gm in foodGameObjectsArray)
                {
                    if (minRange > Vector3.Distance(Character.transform.position, gm.transform.position))
                    {
                        minRange = Vector3.Distance(Character.transform.position, gm.transform.position);
                        targetFood = gm.transform;
                        // Debug.Log(minRange);
                    }
                }

                if (minRange >= maxSearchDistance)
                {
                    targetFood = null;
                }
            }
        }
    }
    void MoveToFood()
    {
        try
        {

            // NavMesh.SamplePosition(GameObject.FindGameObjectWithTag("Food").transform.position * maxSearchDistance + Character.transform.position, out navMeshHit, maxSearchDistance, NavMesh.AllAreas);
            // foodPosition = navMeshHit.position;
            // Debug.Log(NavMesh.CalculatePath(Character.transform.position, navMeshHit.position, 0, Character.navMeshPath));
            // Debug.Log(foodPosition);

            var distance = (targetFood.position - Character.transform.position).magnitude;

            if (distance > eatDistance)
            {
                Character.MoveTo(targetFood.position);
            }
            else
            {
                try
                {
                    EatFood();
                }
                catch
                {
                    Character.SetState(NoFoodState);
                    Debug.Log("Bebra2");
                }
            }
        }
        catch
        {
            Character.SetState(NoFoodState);
            Debug.Log("Bebra3");
        }
    }

    void EatFood()
    {
        Destroy(targetFood.gameObject);
        Character.tempHunger += RestoresEat;
        IsFinished = true;
    }
}
