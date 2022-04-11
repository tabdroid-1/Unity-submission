using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreMain : MonoBehaviour
{
    public SaveManager saveManager;

    public TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    private void Update()
    {
        text.text = "Name: " + saveManager.playerName + " Highscore: " + saveManager.highScore;
    }

    
}
