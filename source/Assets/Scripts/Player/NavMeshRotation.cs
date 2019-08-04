using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshRotation : MonoBehaviour
{
    public float ExtraRotationSpeed;

    void Update()
    {
        if(GetComponent<NavMeshAgent>().velocity != Vector3.zero)
            ExtraRotation();
    }

    void ExtraRotation()
    {
        Vector3 lookrotation = GetComponent<NavMeshAgent>().steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), ExtraRotationSpeed * Time.deltaTime);
    }
}
