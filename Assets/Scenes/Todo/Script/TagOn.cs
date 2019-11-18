using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagOn : MonoBehaviour
{
  [SerializeField]
  GameObject toggleButton;

  // Start is called before the first frame update
  public void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void BluetagisOn()
  {
    var toggle = toggleButton.GetComponent<Toggle>();
    toggle.isOn = true;
    Debug.Log("blueOn");
  }
  public void GreentagisOn()
  {
    var toggle = toggleButton.GetComponent<Toggle>();
    toggle.isOn = true;
    Debug.Log("GreenOn");
  }
}
