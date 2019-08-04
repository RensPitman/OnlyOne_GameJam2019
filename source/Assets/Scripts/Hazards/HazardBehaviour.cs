using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBehaviour : MonoBehaviour
{
    [Header("Properties")]
    public Vector3 Size;
    public Vector3 Offset;

    [Header("Damage")]
    public float Rate;

    [Header("Collision")]
    public LayerMask Mask;

    private bool isDone;

    private void Update()
    {
        if (hasOverlap() && !isDone)
        {
            isDone = true;
            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage()
    {
        GameManager.Player.DestroyAgent(true);
        yield return new WaitForSeconds(Rate);
        isDone = false;
    }

    bool hasOverlap()
    {
        Collider[] coll = Physics.OverlapBox(transform.position + Offset, new Vector3(Size.x - (Size.x/2), Size.y - (Size.y / 2), Size.z - (Size.z / 2)), Quaternion.identity, Mask);

        if (coll.Length > 0)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + Offset, Size);
    }
}
