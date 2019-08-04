using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBehaviour : MonoBehaviour
{
    public bool isMain;
    public NavMeshAgent MyAgent;
    public GameObject MyTarget;

    [Header("Visuals")]
    public GameObject Icon;

    [Header("Animation")]
    public Animator MyAnim;

    [Header("Lost pidgeon")]
    public float Radius;

    private void Start()
    {
        if(!isMain && GameManager.Player.MainAgent != null)
            MyTarget = GameManager.Player.MainAgent.gameObject;

        if (isMain)
            MyTarget = this.gameObject;
    }

    private void Update()
    {
        if(!isMain && MyTarget != null)
            MyAgent.SetDestination(MyTarget.transform.position);

        if (MyAgent != null && MyTarget != null)
        {
            if (MyAgent.velocity != Vector3.zero)
                MyAnim.SetBool("isWalking", true);
            else
                MyAnim.SetBool("isWalking", false);

            if (GameManager.Player.IsEating)
                MyAnim.SetBool("isEating", true);
            else
                MyAnim.SetBool("isEating", false);
        }

        if(MyTarget == null)
        {
            //Look for main agent
            float dist = Vector3.Distance(transform.position, GameManager.Player.MainAgent.transform.position);

            if(dist < Radius)
            {
                MyTarget = GameManager.Player.MainAgent.gameObject;

                GameManager.Player.AllAgents.Add(this.GetComponent<NavMeshAgent>());
            }
        }
    }

    public void ShowDangerIcon()
    {
        Icon.SetActive(true);
    }

    public void HideDangerIcon()
    {
        Icon.SetActive(false);
    }
}
