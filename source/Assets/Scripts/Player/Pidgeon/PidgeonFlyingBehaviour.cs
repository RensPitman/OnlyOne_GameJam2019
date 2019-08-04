using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PidgeonFlyingBehaviour : MonoBehaviour
{
    [Header("Properties")]
    public float MovementSpeed;
    public float UpwardSpeed;
    public float Distance;

    private Vector3 startPos;

    private void Start()
    {
        Vector3 dir = Random.onUnitSphere.normalized * MovementSpeed;
        startPos = transform.position;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(dir.x, UpwardSpeed, dir.z);

        transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, startPos) > Distance)
        {
            Destroy(this.gameObject);
        }
    }
}
