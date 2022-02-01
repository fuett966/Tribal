using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHeightScript : MonoBehaviour
{
    [SerializeField]private float distanceFromGround = 20f;
    [SerializeField]private float movementSpeed;
    [SerializeField]private float movementAcceleration;
    private Rigidbody rigidbody;
    private RaycastHit hit;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(transform.position, -transform.up);
        Physics.Raycast(ray, out hit);
        var rigidbodyPosition = rigidbody.position;
        Debug.Log(hit.point);
        // if (rigidbodyPosition.y < distanceFromGround)
        if (hit.point.y < hit.point.y+distanceFromGround)
        {
            
            var rigidbodyVelocity = rigidbody.velocity;
            // rigidbodyVelocity = Vector3.MoveTowards(rigidbodyVelocity,movementSpeed,movementAcceleration*Time.deltaTime);
            // rigidbody.velocity = rigidbodyVelocity;
            rigidbody.position = new Vector3(rigidbodyPosition.x,hit.point.y+distanceFromGround,rigidbodyPosition.z);
            rigidbody.velocity = new Vector3(rigidbodyVelocity.x,Mathf.Max(0,rigidbodyVelocity.y),rigidbodyVelocity.z);
        }
        // rigidbody.rotation = Quaternion.RotateTowards(rigidbody.rotation,Quaternion.LookRotation())
    }
}
