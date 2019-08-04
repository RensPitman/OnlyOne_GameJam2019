using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : MonoBehaviour
{
    public List<Transform> AllNodes;
    private int nodeIndex;

    public NavMeshAgent Agent;

    private void Update()
    {
        if (Agent.remainingDistance < 0.1f)
        {
            print("NOPE");
            nodeIndex++;
        }

        if (nodeIndex == AllNodes.Count)
            nodeIndex = 0;

        Agent.SetDestination(AllNodes[nodeIndex].position);


    }
}
