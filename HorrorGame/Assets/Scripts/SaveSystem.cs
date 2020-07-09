using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    private static int slotNumber;

    public static void SaveGame(Transform player, int slotNum)
    {
        slotNumber = slotNum;
        string path = GetSavePath();

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        //convert save data to binary and save in the "path"
        formatter.Serialize(stream, data);

        stream.Close();

    }

    public static PlayerData LoadGame(int slotNum)
    {
        slotNumber = slotNum;
        string path = GetSavePath();

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //convert binary to save data & store it in data
            PlayerData data = (PlayerData) formatter.Deserialize(stream);

            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    private static string GetSavePath()
    {
        return Application.persistentDataPath + "/SAVEDATA" + slotNumber + ".sav";
    }
}
