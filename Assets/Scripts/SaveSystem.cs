using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (GameModel gamemodel)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameModel data = new GameModel();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameModel LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameModel data = formatter.Deserialize(stream) as GameModel;
            stream.Close();

            return data;

        } else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
