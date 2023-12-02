using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MenuManager Instance;

    public int BestScore; // new variable declared
    public string BestPlayer; // new variable declared
    public string PlayerName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestPlayer;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        data.BestPlayer = BestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestPlayer = data.BestPlayer;
        }
    }

}
