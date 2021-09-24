
using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float ySpeed = 10.0f;
    public float xSpeed = 100.0f;
    public float zSpeed = 30.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float y = Input.GetAxis("Vertical") * ySpeed;
        float x = Input.GetAxis("Horizontal") * xSpeed;
        float z = zSpeed;
        y *= Time.deltaTime;
        x *= Time.deltaTime;
        z *= Time.deltaTime;
        if (Input.GetMouseButton(0))
            transform.Translate(0, 0, -z);

        if (Input.GetMouseButton(1))
           transform.Translate(0, 0, z );
        transform.Translate(0, y, 0 );
        transform.Translate(x, 0 , 0);
    }
}