using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    /// <summary>
    /// Save player data to binary file.
    /// </summary>
    /// <param name="player"></param>
    public static void SavePlayerData(ScoreManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    /// <summary>
    /// Save player data to binary file.
    /// </summary>
    /// <param name="player"></param>
    public static void SavePlayerData(MainMenu player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    /// <summary>
    /// Load player data in case if it exists.
    /// </summary>
    /// <returns>Loaded data or null.</returns>
    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/player.sav";
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
            Debug.Log("Save file was not found.");
            return null;
        }
    }
}
