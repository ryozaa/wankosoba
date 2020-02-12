using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SSTitle : MonoBehaviour
{
    public GameObject starObj;
    public Button startButton;
    public Button homeButton;

    void Start()
    {
        startButton.onClick.AddListener(() => SceneManager.LoadScene("SobaShooting"));
        homeButton.onClick.AddListener(() => SceneManager.LoadScene("Home"));
    }

    void Update()
    {
        if (Time.frameCount % 5 == 0) {
            Instantiate(starObj);
        }
    }
}
