using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform Target;
    public float MovementSpeed;
    public float Distance;

    private float currentDist;
    private bool isMoving;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Target == null)
            Target = GameManager.Player.MainAgent.transform;
        else
        {
            currentDist = Vector3.Distance(transform.position, Target.position);

            if (currentDist > Distance)
            {
                if (!isMoving)
                    isMoving = true;
            }

            if(isMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, 0, Target.position.z), MovementSpeed * Time.deltaTime);

                if (currentDist < 0.1f)
                    isMoving = false;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Distance);
    }
}
