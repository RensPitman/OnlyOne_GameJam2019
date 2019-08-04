using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountHazardBehaviour : MonoBehaviour
{
    [Header("Properties")]
    public float Distance;
    public int FlockSize;

    [Header("Damage")]
    public float Rate;
    private bool getDamage;

    [HideInInspector]
    public bool hasPlayer;

    private Color gizmoColor;

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, GameManager.Player.MainAgent.transform.position);

        if(dist < Distance)
        {
            if (GameManager.Player.AllAgents.Count <= FlockSize - 1)
            {
                // EDITOR GIZMO COLOR
                gizmoColor = new Color(1, 0, 0, 0.5f);

                hasPlayer = true;

                if (!getDamage)
                {
                    getDamage = true;
                    StartCoroutine(WaitForDamage());
                }

                if (!GameManager.Level.HasPlayer.Contains(this))
                    GameManager.Level.HasPlayer.Add(this);
            }
        }
        else
        {
            // EDITOR GIZMO COLOR
            gizmoColor = new Color(0, 1, 0, 0.5f);

            hasPlayer = false;
            getDamage = false;
            StopCoroutine(WaitForDamage());

            GameManager.Level.HasPlayer.Remove(this);
        }
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(Rate);
        if (hasPlayer)
        {
            GameManager.Player.DestroyAgent(true);
            getDamage = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, Distance);
    }
}
