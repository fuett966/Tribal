using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [HideInInspector]public float count = 0f;
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
