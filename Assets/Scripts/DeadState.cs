using UnityEngine;
[CreateAssetMenu]
public class DeadState : State
{
    public override void Init()
    {
        if (Character.Eat >= -1)
        {
            return;
        }
        else
        {
            Die();
        }
    }
    public override void Run ()
    {
        Die();
    }
    public void Die()
    {
        Destroy(Character.GetComponent<Character>().gameObject);
    }
}
