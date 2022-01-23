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
        bool getCorrectPoint = false;
        while (!getCorrectPoint)
        {
            NavMesh.SamplePosition(Random.insideUnitSphere * MaxDistance + Character.transform.position, out navMeshHit, MaxDistance, NavMesh.AllAreas);
            randomPosition = navMeshHit.position;
            Character.agent.CalculatePath(randomPosition, Character.navMeshPath);
            if (Character.navMeshPath.status == NavMeshPathStatus.PathComplete) { getCorrectPoint = true; }
        }
    }
}
