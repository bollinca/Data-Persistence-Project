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

    // Define what data will be saved, create save "container" class
    [System.Serializable]
    class DataFile
    {
        public string name;
        public int score;
    }
    // Saves high score data to a JSON file
    public void SaveData()
    {
        DataFile dataToFile = new DataFile();
        dataToFile.name = highScorePlayer;
        dataToFile.score = highScore;
        string jsonToFile = JsonUtility.ToJson(dataToFile);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonToFile);
    }
    // Loads high score data from a JSON file
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string jsonFromFile = File.ReadAllText(path);
            DataFile dataFromFile = JsonUtility.FromJson<DataFile>(jsonFromFile);

            highScore = dataFromFile.score;
            highScorePlayer = dataFromFile.name;
        }
    }

}
