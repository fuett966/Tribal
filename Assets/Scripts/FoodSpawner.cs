using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float waitTimeMin = 20.0f;
    public float waitTimeMax = 50.0f;
    [SerializeField]public float waitTime;
    private float timer = 0.0f;
    public GameObject Food;
    public void Start()
    {
        waitTime = Random.Range(waitTimeMin,waitTimeMax);
    }
    public void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = timer - waitTime;
            Instantiate(Food, transform.position + new Vector3(Random.Range(-2f,2f),4,Random.Range(-2f,2f)), transform.rotation);
        }
    }
}
