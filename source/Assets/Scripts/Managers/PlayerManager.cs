using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    public Transform SpawnPoint;

    [Header("Properties")]
    public PlayerBehaviour Behaviour;
    public bool IsMoving;
    public bool IsEating;
    public bool AllowControl = true;

    [Header("NavMesh")]
    public NavMeshAgent MainAgent;
    public List<NavMeshAgent> AllAgents = new List<NavMeshAgent>();

    [Header("Animation")]
    public List<Animator> AllAnimators = new List<Animator>();

    private GameObject indicator;

    public void SpawnIndicator(Vector3 pos)
    {
        if (indicator != null)
            Destroy(indicator);

        indicator = (GameObject)Instantiate(Resources.Load("Player/ent_indicator"), pos, Quaternion.identity);
    }

    public void DestroyIndicator()
    {
        if (indicator != null)
            Destroy(indicator);
    }

    public void SetAgentDestination(Vector3 pos)
    {
        MainAgent.SetDestination(pos);
    }

    public void SpawnAgent()
    {
        GameObject obj = null;

        // Set Target of the MainAgent
        if (MainAgent == null)
        {
            // Spawn the gameObject
            obj = (GameObject)Instantiate(Resources.Load("Player/ent_pidgeon"), SpawnPoint.position, Quaternion.identity);

            obj.GetComponent<NavMeshBehaviour>().MyAgent = obj.GetComponent<NavMeshAgent>();

            MainAgent = obj.GetComponent<NavMeshAgent>();

            MainAgent.GetComponent<SphereCollider>().enabled = true;
            MainAgent.stoppingDistance = 0;
            MainAgent.avoidancePriority = 0;

            MainAgent.GetComponent<NavMeshBehaviour>().isMain = true;
            MainAgent.SetDestination(SpawnPoint.position);
        }
        else
        {
            // Spawn the gameObject
            Vector2 randomPos = Random.insideUnitCircle * 2;
            obj = (GameObject)Instantiate(Resources.Load("Player/ent_pidgeon"), MainAgent.transform.position + new Vector3(randomPos.x, MainAgent.transform.position.y, randomPos.y), Quaternion.identity);

            obj.GetComponent<NavMeshBehaviour>().MyAgent = obj.GetComponent<NavMeshAgent>();
        }

        obj.name = "ent_pigeon" + AllAgents.Count.ToString();
        obj.transform.parent = GameManager.Level.EntityContainer;

        // Add to the list of agents in the manager
        AllAgents.Add(obj.GetComponent<NavMeshAgent>());

    }

    public void DestroyAgent(bool spwnFlying)
    {
        if (AllAgents.Count > 1)
        {
            GameObject agentToDestroy = AllAgents[AllAgents.Count - 1].gameObject;

            AllAgents.RemoveAt(AllAgents.Count - 1);

            if (spwnFlying)
            {
                GameObject obj = (GameObject)Instantiate(Resources.Load("Player/ent_pidgeonFlying"), agentToDestroy.transform.position, Quaternion.identity);
            }

            Destroy(agentToDestroy);
        }
    }

    public void SetDanger(bool state)
    {
        foreach (NavMeshAgent agent in AllAgents)
        {
            if (state)
                agent.GetComponent<NavMeshBehaviour>().ShowDangerIcon();
            else
                agent.GetComponent<NavMeshBehaviour>().HideDangerIcon();
        }
    }
}
