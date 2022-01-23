using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public float TimeToDestroy = 25f; 
    [SerializeField]public float tempTimeToDestroy;
    void Start()
    {
        tempTimeToDestroy = TimeToDestroy;
    }
 
    void Update()
    {
        tempTimeToDestroy-=Time.deltaTime;
        if (tempTimeToDestroy<=0)
        { 
            Destroy(gameObject);
        }
    }
}
