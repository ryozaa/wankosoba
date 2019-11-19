using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleButton : MonoBehaviour, IPointerClickHandler
{
    public Sprite OnSprite;
    public Sprite OffSprite;
    public TimePicker timePicker;

    private Image image;
    private bool isActive;
    
    void Start()
    {
        isActive = false;
        image = GetComponent<Image>();
        image.sprite = OffSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isActive = !isActive;
        if (isActive) {
            image.sprite = OnSprite;
            timePicker.setActive(true);
        }
        else {
            image.sprite = OffSprite;
            timePicker.setActive(false);
        }
    }
}
