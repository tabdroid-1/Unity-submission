using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    //updates highscore
    private void HighScore()
    {

        if (isInMainScene)
        {
            if (mainManager.m_Points > highScore)
            {
                highScore = mainManager.m_Points;
            }
        }

    }

    public void SetName()
    {
        playerName = inputField.text;
        Debug.Log(playerName);
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore = highScore;
        public string playerName;
        public string highScoreOwner;

    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
