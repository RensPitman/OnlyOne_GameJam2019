using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public float MovementSpeed;
    public Vector3 Direction;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, MovementSpeed * Time.deltaTime);
    }
}
