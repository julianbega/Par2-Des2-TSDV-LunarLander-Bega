using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{  
    
    public static void SaveHighScore(PlayerData actualData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HighScore.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(actualData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadHighScore()
    {
        string path = Application.persistentDataPath + "/HighScore.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData highScoreData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return highScoreData;
        }
        else 
        {
            return null;
        }
    }


}
