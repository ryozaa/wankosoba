using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Clothes : MonoBehaviour
{
    private string key;
    public Detail detail;
    public Sprite sprite;
    public Image image;
    public Image lockIcon;
    public string type;
    public string spriteName;
    public string spriteName2;
    public bool isLock = true;
    public int price;
    public string desc;
    private Button button;
    public bool reset = false;

    void Start()
    {
        image.sprite = sprite;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        key = sprite.name;
        SetIsLock(PlayerPrefs.GetInt(key, 0) == 0);

        if (key.Substring(key.Length-2, 2) == "_1") {
            SetIsLock(false);
        }
        else if (reset) {
            SetIsLock(true);
        }
    }

    void OnClick() {
        detail.SetClothe(this);
    }

    public void SetIsLock(bool state) {
        isLock = state;
        lockIcon.gameObject.SetActive(isLock);

        PlayerPrefs.SetInt(key, isLock? 0 : 1);
        PlayerPrefs.Save();
    }
}
