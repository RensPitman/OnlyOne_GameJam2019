﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager manager;
    static PlayerManager player;
    static LevelManager level;
    static InGameInterfaceManager ui;
    static GameplayManager gameplay;

    public static GameManager Manager
    {
        get
        {
            if (manager == null)
                manager = FindObjectOfType<GameManager>();

            return manager;
        }
    }

    public static PlayerManager Player
    {
        get
        {
            if (player == null)
                player = FindObjectOfType<PlayerManager>();

            return player;
        }
    }

    public static LevelManager Level
    {
        get
        {
            if (level == null)
                level = FindObjectOfType<LevelManager>();

            return level;
        }
    }

    public static InGameInterfaceManager UI
    {
        get
        {
            if (ui == null)
                ui = FindObjectOfType<InGameInterfaceManager>();

            return ui;
        }
    }

    public static GameplayManager Gameplay
    {
        get
        {
            if (gameplay == null)
                gameplay = FindObjectOfType<GameplayManager>();

            return gameplay;
        }
    }

}
