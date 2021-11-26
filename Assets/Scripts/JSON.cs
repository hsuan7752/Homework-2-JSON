using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSON : MonoBehaviour
{
    [Header("File Path")]
    public string path;

    // Start is called before the first frame update
    void Start()
    {
        List<string> equips = new List<string>();
        equips.Add("sword");
        equips.Add("shield");

        Data newData = new Data
        {
            health = 100,
            money = 250,
            equip = equips
        };

        string jsonInfo = JsonUtility.ToJson(newData, true);
        File.WriteAllText(path + "/test.json", jsonInfo);

        Debug.Log("The file has been writen.");
    }
}

public class Data
{
    public float health;
    public int money;
    public List<string> equip;
}
