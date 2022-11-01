using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveToFile
{
    // Saves high scores and highest stars earned from each level played to a binary file
    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "LevelData";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavaData data = new SavaData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // Loads high scores and highest stars earned from each level played from a binary file
    public static SavaData Load()
    {
        string path = Application.persistentDataPath + "LevelData";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavaData data = formatter.Deserialize(stream) as SavaData;
            stream.Close();

            return data;
        }
        else
        {
            //Debug.Log("File not found");
            return null;
        }
    }
}
