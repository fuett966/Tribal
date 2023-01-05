using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("2");
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.transform.parent = null;
        }
    }
}
