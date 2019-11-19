using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    public List<IconButton> IconButtonList;

    public IconButton FaceButton;

    public int selectedId = 0;
    
    void Start()
    {
        FaceButton.GetComponent<Button>().image.color = new Color(1f, 1f, 1f, 1f);
    }

    public void UnSelectAll()
    {
        foreach (var button in IconButtonList) {
            button.UnSelect();
        }
    }
}
