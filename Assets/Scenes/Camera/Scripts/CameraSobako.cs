using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CameraSobako : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Button closeButton;
    private Animator animator;
    private List<string> motionList;

    void Start()
    {
        animator = GetComponent<Animator>();
        motionList = new List<string>{"笑顔1", "笑顔2", "笑顔3", "得意げ", "ねむい", "ルンルン", "驚く"};

        closeButton.onClick.AddListener(() => SceneManager.LoadScene("Home"));
    }

    public void OnPointerDown(PointerEventData data){}

    public void OnDrag(PointerEventData data)
    {
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(data.position);
        TargetPos.z = 0;
        transform.position = TargetPos;
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (data.dragging) return;
        animator.Play(motionList[UnityEngine.Random.Range(0, motionList.Count)]);
    }
}
