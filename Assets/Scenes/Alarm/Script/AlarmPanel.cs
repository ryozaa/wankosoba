using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlarmPanel : MonoBehaviour
{
    public Text TimeText;
    public Button DeleteButton;
    public Button ToggleButton;
    public Sprite OnSprite;
    public Sprite OffSprite;

    private int id;
    private bool state = true;

    void Start() {
        ToggleButton.onClick.AddListener(toggle);
        DeleteButton.onClick.AddListener(delete);
    }

    public void Init(int id, string time, bool state) {
        this.id = id;
        this.state = state;
        TimeText.text = time;
    }

    private void toggle() {
        this.setState(!this.state);
    }

    private void setState(bool v) {
        this.state = v;
        Sprite sprite = null;
        if (v) {
            sprite = OnSprite;
        } else {
            sprite = OffSprite;
        }
        this.ToggleButton.targetGraphic.GetComponent<Image>().sprite = sprite;
    }

    private void delete()
    {
        AlarmTable.DeleteById(id);
        Destroy(gameObject);
    }
}
