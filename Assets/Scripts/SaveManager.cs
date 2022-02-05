using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;
   
    public string currentPlayer;
    public string highScorePlayer;
    public int highScore;

    //public static string playerName;
    //public static int highScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        LoadData();
        Destroy(this);
    }

    [System.Serializable]
    class DataHolder
    {
        public string name;
        public int score;
    }

    public void SaveData()
    {
        print("RUNNING SAVE DATA");
        DataHolder dataToFile = new DataHolder();
        dataToFile.name = highScorePlayer;
        dataToFile.score = highScore;
        string jsonToFile = JsonUtility.ToJson(dataToFile);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonToFile);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string jsonFromFile = File.ReadAllText(path);
            DataHolder dataFromFile = JsonUtility.FromJson<DataHolder>(jsonFromFile);
            print(jsonFromFile);

            highScore = dataFromFile.score;
            highScorePlayer = dataFromFile.name;
            print("DATA LOADED");
            print("High score is " + highScore);
            print("Best player is " + highScorePlayer);
        }
    }

}
