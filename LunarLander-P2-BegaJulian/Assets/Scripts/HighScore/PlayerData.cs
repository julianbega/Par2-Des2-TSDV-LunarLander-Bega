using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float score;
    public string playerName;

    public PlayerData(GameManager player)
    {
        Debug.Log("player name to save = " + player.playerName);
        playerName = player.playerName;
        score = player.playerManager.score;
    }
}