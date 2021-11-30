using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string player1Name = "";
    public string player2Name = "";
    public int score = 0;

    public PlayerData(Player player)
    {
        player1Name = player.playerName1;
        player2Name = player.playerName2;
        score = player.score;
    }
}
