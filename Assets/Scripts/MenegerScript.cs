using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenegerScript : MonoBehaviour
{
    public GameObject [] foodMassive;
    public GameObject [] monsterMassive;
    public GameObject [] mushrumMassive;
    public GameObject [] heroMassive;
    void Start()
    {
        foodMassive = GameObject.FindGameObjectsWithTag("Food");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
