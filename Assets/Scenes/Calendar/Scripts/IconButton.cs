using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconButton : MonoBehaviour
{
    public IconManager IconManager;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        var button = GetComponent<Button>();
        button.onClick.AddListener(Select);
        UnSelect();
    }

    public void Select()
    {
        IconManager.UnSelectAll();
        image.color = new Color(1f, 1f, 1f, 1f);
    }

    public void UnSelect()
    {
        image.color = new Color(1f, 1f, 1f, 0.3f);
    }
}
