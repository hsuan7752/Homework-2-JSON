using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSON : MonoBehaviour
{
    [Header("File Path")]
    private string path;

    Data[] datas;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The file has been start.");
        path = Application.dataPath;        

        Load();
    }

    public Data[] Load()
    {
        Debug.Log("The file has been load.");

        string jsonInfo = File.ReadAllText(path + "/record.json");
        datas = JsonHelper.FromJson<Data>(jsonInfo);

        return datas;
    }

    public void addData(string name1, string name2, int score)
    {
        Data newData = new Data
        {
            player1Name = name1,
            player2Name = name2,
            score = score
        };

        datas = AddtoArray(datas, newData);
    }

    public void Save()
    {
        string jsonInfo = JsonHelper.ToJson(datas, true);

        Debug.Log(jsonInfo);

        File.WriteAllText(path + "/record.json", jsonInfo);

        Debug.Log("The file has been writen.");
    }

    void OnDisable()
    {
        Save();
    }

    public T[] AddtoArray<T>(T[] originalData, T addValue)
    {
        if (originalData == null)
        {
            originalData = new T[1];
            originalData[0] = addValue;
            return originalData;
        }

        T[] newData = new T[originalData.Length + 1];
        originalData.CopyTo(newData, 0);
        newData[originalData.Length] = addValue;
        return newData;
    }
}

[System.Serializable]
public class Data
{
    public string player1Name;
    public string player2Name;
    public int score;
}
