using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public MainManager mainManager;

    public int highScore;
    [HideInInspector]
    public string playerName;
    public string highScoreOwner;

    string currentScene;
    bool isInMainScene;

    public Buttons buttons;

    // Start is called before the first frame update
    void Start()
    {
        highScore = Instance.highScore;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if game is in main scene
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "main")
        {
            isInMainScene = true;
            mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        }

        HighScore();

        Debug.Log(playerName);
    }


    //data persistence between scenes
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
        LoadSave();
    }

    //updates highscore
    private void HighScore()
    {

        if (isInMainScene)
        {
            if (mainManager.m_Points > highScore)
            {
                highScore = mainManager.m_Points;
                highScoreOwner = playerName;
            }
        }

    }

    public void SetName(string name)
    {
        playerName = name;
    }

    

    [System.Serializable]
    public class SaveData
    {
        public int HighScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.HighScore;
        }
    }
}
