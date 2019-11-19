using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menubar : MonoBehaviour
{
    public Button homeButton;
    public Button alarmButton;
    public Button calendarButton;
    public Button todoButton;

    void Start()
    {
        homeButton.onClick.AddListener(() => SceneManager.LoadScene("Home"));
        alarmButton.onClick.AddListener(() => SceneManager.LoadScene("Alarm"));
        calendarButton.onClick.AddListener(() => SceneManager.LoadScene("Calendar"));
        todoButton.onClick.AddListener(() => SceneManager.LoadScene("Todo"));
    }
}
