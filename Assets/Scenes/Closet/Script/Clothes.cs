using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Clothes : MonoBehaviour
{
    public Detail detail;
    public Sprite sprite;
    public Image lockIcon;
    public string type;
    public string spriteName;
    public string spriteName2;
    public bool isLock = true;
    private Button button;
    
    void Start()
    {
        GetComponent<Image>().sprite = sprite;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick() {
        detail.SetClothe(this);
    }

    public void SetIsLock(bool state) {
        isLock = state;
        lockIcon.gameObject.SetActive(isLock);
    }
}
