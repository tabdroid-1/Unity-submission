using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreMenu : MonoBehaviour
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
        text.text = "Name: " + saveManager.highScoreOwner + " Highscore: " + saveManager.highScore;
    }

}
