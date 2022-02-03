using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public static string playerName;
    public static int highScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        Destroy(this);
    }

    public void saveData()
    {
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadData()
    {

    }

    [System.Serializable]
    class SaveData
    {
        public string name = playerName;
        public int score = highScore;
    }

}
