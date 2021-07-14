using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float score;
    public string playerName;

    public PlayerData(PlayerData actualData)
    {
        Debug.Log("player name to save = " + actualData.playerName);
        playerName = actualData.playerName;
        score = actualData.score;
    }
}