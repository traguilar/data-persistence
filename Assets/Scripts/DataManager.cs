using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string playerName;

    public int highScore = 0;
    public string highScoreName = "";

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetRandomName()
    {
        return "RandomGuy01234";
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.name = highScoreName;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);   
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.score;
            highScoreName = data.name;
        }
    }


}
