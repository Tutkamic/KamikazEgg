using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevels()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levels.mt";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadLeveles()
    {
        string path = Application.persistentDataPath + "/levels.mt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();

            return data;

        } else
        {
            Debug.LogError("Save file do not found");
            return null;
        }
    }

}
