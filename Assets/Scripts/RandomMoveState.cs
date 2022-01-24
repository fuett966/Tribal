using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu]
public class RandomMoveState : State
{
    public float MaxDistance = 5f;

    Vector3 randomPosition;
    NavMeshHit navMeshHit;


    public override void Init()
    {
        CreateRandomPoint();
    }

    public override void Run()
    {
        if (IsFinished)
        {
            return;
        }
        else
        {
            if ((randomPosition - Character.transform.position).magnitude > 0.55f)
            {
                Character.MoveTo(randomPosition);
            }
            else
            {
                IsFinished = true;
            }
        }
    }

    public void CreateRandomPoint()
    {
        NavMesh.SamplePosition(Random.insideUnitSphere * MaxDistance + Character.transform.position, out navMeshHit, MaxDistance, NavMesh.AllAreas);
        randomPosition = navMeshHit.position + new Vector3(x: 0f, y: 0.5f, z: 0f);
        // + new Vector3(x: 0f, y: 0.7f, z: 0f)
        try
        {
            Character.agent.CalculatePath(randomPosition, Character.navMeshPath);
        }
        catch
        {
            Character.ChoiceState();
        }
    }
}
