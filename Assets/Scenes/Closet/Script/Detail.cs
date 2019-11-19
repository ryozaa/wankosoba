using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detail : MonoBehaviour
{
    public Image image;
    public Button button;
    public ClosetSobako sobako;

    private string type;
    private string key1;
    private string key2;

    public void ChangeSprite(Sprite sprite) {
        image.sprite = sprite;
        button.onClick.AddListener(OnClickButton);
    }

    public void setEyeColor(string rightColor, string leftColor) {
        type = "eye";
        key1 = rightColor;
        key2 = leftColor;
    }

    public void setHairName(string name) {
        type = "hair";
        key1 = name;
    }

    public void setClotheName(string name) {
        type = "clothe";
        key1 = name;
    }

    void OnClickButton() {
        switch (type) {
            case "eye":
                sobako.setRightEyeColor(key1);
                sobako.setLeftEyeColor(key2);
                break;
            case "hair":
                sobako.setHairName(key1);
                break;
            case "clothe":
                sobako.setClotheName(key1);
                break;
        }
        sobako.Action();
    }
}
