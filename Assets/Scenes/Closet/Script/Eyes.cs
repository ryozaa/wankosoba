using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Eyes : MonoBehaviour
{
    public Detail detail;
    public Sprite clotheSprite;
    public string rightColor;
    public string leftColor;
    private Button button;

    void Start()
    {
        GetComponent<Image>().sprite = clotheSprite;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick() {
        detail.ChangeSprite(clotheSprite);
        detail.setEyeColor(rightColor, leftColor);
    }
}
