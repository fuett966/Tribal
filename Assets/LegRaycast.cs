using UnityEngine;

public class LegRaycast : MonoBehaviour
{
    private RaycastHit hit;
    private new Transform transform;
    public Vector3 Position => hit.point;
    public Vector3 Normal => hit.normal;
    private void Awake()
    {
        transform = base.transform;
    }
    void Update()
    {
        var ray = new Ray(transform.position, -transform.up);
        Physics.Raycast(ray, out hit);
        Debug.DrawLine(transform.position,-transform.up,Color.red);
    }
}
