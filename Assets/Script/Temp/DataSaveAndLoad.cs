using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class PlayerData
{
    public int[] inputs;

    public PlayerData()
    {
        inputs = new int[(int)KeyAction.None];
        for (int i = 0; i < (int)KeyAction.None; i++)
        {
            //inputs[i] = (int)InputSetting.keys[(KeyAction)i];
        }
    }
}

public static class SaveSystem
{
    public static void Save(PlayerData _data, string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Create);

        formatter.Serialize(stream, _data);
        stream.Close();
    }

    public static PlayerData Load(string filePath)
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("저장된 데이터 없음" + filePath);
            return null;
        }
    }
}
