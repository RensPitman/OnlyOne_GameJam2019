using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerBehaviour behaviour;

    public LayerMask ClickMask;

    private void Awake()
    {
        behaviour = GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        if (GameManager.Player.AllowControl)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Player.SpawnIndicator(GetMousePos());
                GameManager.Player.SetAgentDestination(GetMousePos());
            }
        }
    }

    Vector3 GetMousePos()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f, ClickMask))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}
