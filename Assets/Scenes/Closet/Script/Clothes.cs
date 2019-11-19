using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Clothes : MonoBehaviour
{
    public Detail detail;
    public Sprite sprite;
    public string type;
    public string spriteName;
    private Button button;

    void Start()
    {
        GetComponent<Image>().sprite = sprite;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick() {
        detail.ChangeSprite(sprite);
        switch (type) {
            case "clothe":
                detail.setClotheName(spriteName);
                break;
            case "hair":
                detail.setHairName(spriteName);
                break;
        }
    }
}
