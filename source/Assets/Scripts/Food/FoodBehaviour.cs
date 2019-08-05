using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodBehaviour : MonoBehaviour
{
    [Header ("Properties")]
    public Vector3 Size;
    public Vector3 Offset;
    public int SpawnAmount = 1;

    [Header("Collision")]
    public LayerMask Mask;

    private bool isDone;

    [Header("Food")]
    public int BiteAmount;
    public float BiteRate;
    private bool isEating;
    private int biteIndex;

    public bool isInterface;
    public bool Quit;

    private void Update()
    {
        if (hasOverlap() && !isDone)
        {
            if (!GameManager.Player.IsMoving)
            {
                if (biteIndex == 0)
                {
                    biteIndex = 1;
                    isEating = true;
                    GameManager.Player.IsEating = true;
                    StartCoroutine(WaitForBite());
                }

                if (biteIndex == BiteAmount + 1)
                {
                    isDone = true;
                    isEating = false;
                    GameManager.Player.IsEating = false;

                    if (!isInterface)
                    {
                        for (int i = 0; i < SpawnAmount; ++i)
                        {
                            GameManager.Player.SpawnAgent();

                            Destroy(this.gameObject);
                        }
                    }
                    else
                    {
                        if (Quit)
                            Application.Quit();
                        else
                            StartCoroutine(WaitForScene());
                    }

                    
                }
            }
        }
        else
        {
            isEating = false;
            
            biteIndex = 0;
        }
    }

    IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(1);
    }

    IEnumerator WaitForBite()
    {
        while (isEating)
        {
            yield return new WaitForSeconds(BiteRate);
            Instantiate(Resources.Load("Particles/part_munch"), transform.position, Quaternion.identity);
            biteIndex++;
        }
    }

    bool hasOverlap()
    {
        Collider[] coll = Physics.OverlapBox(transform.position + Offset, new Vector3(Size.x, Size.y, Size.z), Quaternion.identity, Mask);

        if(coll.Length > 0)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position + Offset, Size);
    }
}
