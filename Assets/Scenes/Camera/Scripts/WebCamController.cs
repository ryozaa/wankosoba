using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamController : MonoBehaviour
{
  public Camera camera;
  private int width = 1080;
  private int height = 1920;
  private int fps = 60;
  WebCamTexture webcamTexture;
  public Button closeButton;
  public Button shutterButton;
  
  void Start()
  {
    RawImage rawImage = GetComponent<RawImage>();

    WebCamDevice[] devices = WebCamTexture.devices;
    if (devices.Length == 0) return;

    webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
    rawImage.material.mainTexture = webcamTexture;

    webcamTexture.Play();

    RectTransform recTrans = GetComponent<RectTransform>();
    float scale = ((webcamTexture.width / webcamTexture.height) > camera.aspect) ? ((float)camera.pixelHeight / webcamTexture.width) : ((float)camera.pixelWidth / webcamTexture.height);
    recTrans.sizeDelta = new Vector2(scale * webcamTexture.width, scale * webcamTexture.height);
    recTrans.Rotate(new Vector3(0, 0, -90));

    // closeButton.onClick.AddListener();
    shutterButton.onClick.AddListener(Capture);
  }

  // void ChangeDevice()
  // {
  //   RawImage rawImage = GetComponent<RawImage>();
  //   WebCamDevice[] devices = WebCamTexture.devices;
  //   if (devices.Length == 0) return;

  //   int device = ++deviceIndex % devices.Length;
  //   webcamTexture = new WebCamTexture(devices[device].name, this.width, this.height, this.fps);
  //   rawImage.material.mainTexture = webcamTexture;

  //   webcamTexture.Play();
  // }

  void Capture()
  {
    // shutterButton.gameObject.SetActive(false);
    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
    ScreenCapture.CaptureScreenshot(filename);
    // shutterButton.gameObject.SetActive(true);
  }
}
