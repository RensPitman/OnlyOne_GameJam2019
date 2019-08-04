using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Player.MainAgent == null)
        {
            GameManager.Player.SpawnAgent();
        }
    }

    private void Update()
    {
        if (GameManager.Player.MainAgent.remainingDistance == 0)
            GameManager.Player.DestroyIndicator();

        if (GameManager.Player.MainAgent.velocity != Vector3.zero)
            GameManager.Player.IsMoving = true;
        else
            GameManager.Player.IsMoving = false;

    }

}
