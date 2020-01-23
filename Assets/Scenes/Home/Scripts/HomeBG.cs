using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeBG : MonoBehaviour
{
    public static Sprite sprite;
    public Image background;
    public Sprite init;
    void Start()
    {   
        if (sprite == null) {
            background.sprite = init;
        }
        else {
            background.sprite = sprite;
        }
    }
}
