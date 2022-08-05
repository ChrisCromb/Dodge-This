using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame(EnemySpawner es, UIController uic, LevelData ld, SettingsData sd)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.dodgethis";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(es, uic, ld, sd);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveGame(int hs, int ul, SettingsData sd)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.dodgethis";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(hs, ul, sd);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.dodgethis";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadGame()
    {
        string path = Application.persistentDataPath + "/data.dodgethis";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter(); //CREATE IF IT DOESN'T EXIST
            FileStream stream = new FileStream(path, FileMode.Create);

            SaveData data = new SaveData();

            formatter.Serialize(stream, data);
            stream.Close();

            //

            BinaryFormatter formatter2 = new BinaryFormatter(); //LOAD NEW DATA
            FileStream stream2 = new FileStream(path, FileMode.Open);

            SaveData data2 = formatter.Deserialize(stream2) as SaveData;
            stream.Close();

            return data2;


            //return null;
        }
    }
}
