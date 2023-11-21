using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JsonReadWriteSystem : MonoBehaviour
{
    public Text Score;
    private string savePath = "/SaveDataFile.json";

    public void SaveJson()
    {
        SaveData data = new SaveData();

        data.ScoreText = Score.text;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + savePath, json);
    }

    public void LoadFromJson()
    {
        string path = Application.persistentDataPath + savePath;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);         
        }
        else
        {
            Debug.Log("Файл не найден");
        }      
    }

}
