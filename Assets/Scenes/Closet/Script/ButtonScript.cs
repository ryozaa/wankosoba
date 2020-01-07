using System;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{

  public ButtonManager buttonManager;
  public GameObject scroll;
  
  public Sprite on;
  public Sprite off;

  private Image image;
  private bool isOn = false;

    // Start is called before the first frame update
    void Start(){
      image = GetComponent<Image>();

    }

    public void onClick(){

      if(!isOn){
        buttonManager.UnSelectAll();
        ButtonOn();
        scroll.SetActive(true);
      }
    }

    public void ButtonOn(){
      isOn = true;
      // Debug.Log("オン");
      image.sprite = on;
    }

    public void ButtonOff(){
      isOn = false;
      // Debug.Log("オフ");
      image.sprite = off;
    }
}
