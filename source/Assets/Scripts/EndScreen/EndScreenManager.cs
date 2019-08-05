using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public float WaitTime;
    public float SpawnRate;
    public int BirdAmount;

    private int birdIndex;

    [Header("UI")]
    public Text BirdAmountText;

    private void Awake()
    {
        BirdAmount = PlayerPrefs.GetInt("BirdCount");
    }

    private void Start()
    {
        StartCoroutine(WaitForSpawning());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(1);

        if (Input.GetKeyDown(KeyCode.Space))
            Application.Quit();
    }

    private void Spawn()
    {
        StartCoroutine(DoSpawingDude());
    }

    IEnumerator DoSpawingDude()
    {
        while (birdIndex < BirdAmount)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);

            GameObject obj = (GameObject)Instantiate(Resources.Load("Player/ent_pidgeonRigid"), pos + Random.onUnitSphere * 0.5f, Quaternion.identity);
            birdIndex++;

            BirdAmountText.text = "Your flock is " + birdIndex.ToString() +" pidgeons in size!";

            yield return new WaitForSeconds(SpawnRate);
        }
    }

    IEnumerator WaitForSpawning()
    {
        yield return new WaitForSeconds(WaitTime);
        Spawn();
    }
}
