using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    public List<IconButton> IconButtonList;

    public IconButton FaceButton;
    
    void Start()
    {
        // FaceButton.Select();
    }

    public void UnSelectAll()
    {
        foreach (var button in IconButtonList) {
            button.UnSelect();
        }
    }
}
