using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string loadedPlayerName;
    public float loadedhighScore;

    public PlayerData(ScoreManager player)
    {
        loadedPlayerName = player.playerName;
        loadedhighScore = player.highScore;
    }

    public PlayerData(MainMenu player)
    {
        loadedPlayerName = player.playerName;
        loadedhighScore = player.highScore;
    }
}
