using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [HideInInspector]public float count = 0f;
    // Start is called before the first frame update
    void Start()
    {
        count=0f;
        GameEvents.current.onFoodWasEat += onFoodWasEat;
    }

    public void onFoodWasEat()
    {
        count += 1;
        Debug.Log(count);
    }
}
