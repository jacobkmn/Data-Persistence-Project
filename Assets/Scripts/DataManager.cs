using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string currentPlayerName;
    public int currentFinalScore;
    public int BestScore;
    public string BestScoreHolder;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        LoadHighScoreData();
    }

    [System.Serializable]
    class SaveData
    {
        //public string name;
        //public int score;
        public int currentHighScore;
        public string highScoreHolder;
    }

    [SerializeField]
    SaveData data = new SaveData();

    //public void SaveName()
    //{
    //    SaveData data = new SaveData();
    //    data.name = currentPlayerName;

    //    string json = JsonUtility.ToJson(data);
    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //public string LoadName()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        return data.highScoreHolder;
    //    }
    //    else return null;
    //}

    public void SaveScore()
    {
        //data.score = currentFinalScore;

        if (currentFinalScore > BestScore)
        {
            data.currentHighScore = currentFinalScore;
            BestScore = data.currentHighScore;
            data.highScoreHolder = currentPlayerName;
            BestScoreHolder = data.highScoreHolder;
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //public int? LoadBestScore()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        SaveData data = JsonUtility.FromJson<SaveData>(json);

    //        return BestScore;
    //    }
    //    else return null;
    //}

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.currentHighScore;
            BestScoreHolder = data.highScoreHolder;
        }
    }
}
