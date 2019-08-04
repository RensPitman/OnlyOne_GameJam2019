using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform EntityContainer;

    public List<AmountHazardBehaviour> HasPlayer = new List<AmountHazardBehaviour>();

    private void Update()
    {
        if (HasPlayer.Count > 0)
            GameManager.Player.SetDanger(true);
        else
            GameManager.Player.SetDanger(false);
    }
}
