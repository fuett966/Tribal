using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float waitTime = 30.0f;
    private float timer = 0.0f;
    public GameObject Food;
    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = timer - waitTime;
            Instantiate(Food, transform.position + new Vector3(Random.Range(-2f,2f),3,Random.Range(-2f,2f)), transform.rotation);
        }
    }
}
