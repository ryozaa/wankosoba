using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GSButtonManager : MonoBehaviour
{
    public Button backButton;
    public Button shootingButton;
    public Button blockButton;

    void Start()
    {
        backButton.onClick.AddListener(() => SceneManager.LoadScene("Home"));
        shootingButton.onClick.AddListener(() => SceneManager.LoadScene("SobaShooting"));
        blockButton.onClick.AddListener(() => SceneManager.LoadScene("BBTitle"));
    }
}
