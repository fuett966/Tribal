using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }
    public event Action onFoodWasEat;
    public event Action onHeroDied;
    public void FoodWasEat()
    {
        if(onFoodWasEat != null)
        {
            onFoodWasEat();
        }
    }
    public void HeroDied()
    {
        if(onHeroDied != null)
        {
            onHeroDied();
        }
    }
}