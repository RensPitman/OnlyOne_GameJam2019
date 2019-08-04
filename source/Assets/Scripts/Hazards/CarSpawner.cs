using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public Vector3 Direction = new Vector3(0, 0, 1);
    private bool isSpawning = true;

    public float MinRate;
    public float MaxRate;

    private void Start()
    {
        StartCoroutine(WaitForCarSpawn());
    }

    void SpawnCar()
    {
        GameObject obj = (GameObject)Instantiate(Resources.Load("Hazards/ent_car"), transform.position, Quaternion.identity);
        obj.transform.parent = transform;

        obj.GetComponent<CarBehaviour>().Direction = Direction;
    }

    IEnumerator WaitForCarSpawn()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(MinRate, MaxRate));
            SpawnCar();
        }
    }
}
