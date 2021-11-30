using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName1 = "123";
    public string playerName2 = "456";
    public int score = 100;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveSystem.LoadData();

        playerName1 = data.player1Name;
        playerName2 = data.player2Name;
        score = data.score;

        //SaveSystem.AddData(this);
    }

    void OnDisable()
    {
        SaveSystem.SaveData(this);
    }
}
