using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputField : MonoBehaviour
{
    public TMP_InputField inputField;

    public SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        inputField.onValueChanged.AddListener(delegate { saveManager.SetName(inputField.text); });
    }
}
