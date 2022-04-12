using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public SaveManager saveManager;

    private void Update()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitButton()
    {
        saveManager.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
