﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detail : MonoBehaviour
{
    public Image image;
    public Button button;
    public ClosetSobako sobako;
    public Image background;
    public Clothes clothe;
    private Text buttonText;
    private Text descText;
    
    void Start() {
        button.onClick.AddListener(OnClickButton);
        buttonText = button.transform.Find("Text").GetComponent<Text>();
        descText = transform.Find("Desc").GetComponent<Text>();
        SetClothe(clothe);
    }

    public void SetClothe(Clothes clothe) {
        this.clothe = clothe;
        image.sprite = clothe.sprite;
        descText.text = clothe.desc;
        UpdateButton();
    }

    void OnClickButton() {
        if (clothe.isLock) {
            clothe.SetIsLock(false);
            UpdateButton();
            return;
        }

        switch (clothe.type) {
            case "eye":
                sobako.setRightEyeColor(clothe.spriteName);
                sobako.setLeftEyeColor(clothe.spriteName2);
                break;
            case "hair":
                sobako.setHairName(clothe.spriteName);
                break;
            case "clothe":
                sobako.setClotheName(clothe.spriteName);
                break;
            case "background":
                background.sprite = image.sprite;
                break;
        }
        sobako.Action();
    }

    void UpdateButton() {
        string text = "";
        if (clothe.isLock) {
            text = $"購入\n￥{clothe.price}";
        } else {
            text = "きせかえ";
        }
        buttonText.text = text;
    }
}
