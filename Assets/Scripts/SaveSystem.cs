using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    public static void SaveData(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/player.file";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void AddData(Player player)
    {
        PlayerData data = new PlayerData(player);

        if (playerDatasSize == 0)
        {
            playerDatas = new PlayerData[1];
            playerDatas[0] = data;
        }
        else
        {
            PlayerData[] tempPtr = new PlayerData[playerDatas.Length + 1];

            for (int i = 0; i < playerDatas.Length; ++i)
                tempPtr[i] = playerDatas[i];

            tempPtr[playerDatas.Length] = data;

            playerDatas = tempPtr;

            ++playerDatasSize;
        }       
    }

    public static PlayerData LoadData()
    {
        string path = Application.dataPath + "/player.file";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not be found int" + path);
            return null;
        }
    }

    private static PlayerData[] playerDatas;
    private static int playerDatasSize = 0;
}
