using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public InputField inputField;
    public Button backButton;
    public Button updateButton;

    void Start()
    {
        string key = "CHARACTER_NAME";
        inputField.text = PlayerPrefs.GetString(key, "そばこ");
        backButton.onClick.AddListener(() => SceneManager.LoadScene("Home"));
        updateButton.onClick.AddListener(() => {
            PlayerPrefs.SetString(key, inputField.text);
            SceneManager.LoadScene("Home");
        });
    }
}
