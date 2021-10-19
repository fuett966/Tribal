using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathReporter : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onHeroDied += onHeroDied;
    }

    public void onHeroDied()
    {
        Debug.Log("Умер персонаж!");
    }
}
