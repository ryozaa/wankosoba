using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public List<ButtonScript> ButtonList;
    public List<GameObject> ScrollList;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void UnSelectAll(){
      foreach(ButtonScript button in ButtonList){
        button.ButtonOff();
      }
      foreach(GameObject scroll in ScrollList){
        scroll.SetActive(false);
      }
    }


}
