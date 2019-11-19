using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アニメーション一覧
// 通常 しょぼん ねむい ルンルン 疑問 驚く
// 照れる1 照れ困 笑顔1 笑顔2 笑顔3 得意げ 目そらし

public class ClosetSobako : MonoBehaviour
{
    private string rightEyeColor = "green";
    private string leftEyeColor = "green";
    private string hairName = "yellow";
    private string clotheName = "blue";
    private Dictionary<string, int> rightEyeDict;
    private Dictionary<string, int> leftEyeDict;
    private Dictionary<string, List<int>> hairDict;
    private Dictionary<string, List<int>> clotheDict;
    private Animator animator;
    private List<string> motionList;

    void Start()
    {
        rightEyeDict = new Dictionary<string, int>();
        rightEyeDict.Add("green", 27);
        rightEyeDict.Add("pink", 100);
        rightEyeDict.Add("blue", 101);
        rightEyeDict.Add("skyblue", 102);
        rightEyeDict.Add("yellow", 103);
        rightEyeDict.Add("orange", 104);
        rightEyeDict.Add("red", 105);
        rightEyeDict.Add("purple", 99);

        leftEyeDict = new Dictionary<string, int>();
        leftEyeDict.Add("green", 28);
        leftEyeDict.Add("red", 97);
        leftEyeDict.Add("orange", 96);
        leftEyeDict.Add("yellow", 95);
        leftEyeDict.Add("skyblue", 94);
        leftEyeDict.Add("blue", 93);
        leftEyeDict.Add("pink", 92);
        leftEyeDict.Add("purple", 91);

        hairDict = new Dictionary<string, List<int>>();
        hairDict.Add("yellow", new List<int>() {15, 16, 17, 31, 14, 35});
        hairDict.Add("pink", new List<int>() {77, 82, 85, 31, 74, 110});
        hairDict.Add("blue", new List<int>() {78, 83, 86, 31, 75, 109});
        hairDict.Add("hair4", new List<int>() {79, 107, 111});
        hairDict.Add("hair5", new List<int>() {80, 107, 112, 113, 114});

        clotheDict = new Dictionary<string, List<int>>();
        clotheDict.Add("blue", new List<int>() {42, 4, 44, 6, 7, 8, 9, 88, 89});
        clotheDict.Add("green", new List<int>() {46, 47, 48, 49, 50, 51, 52, 118, 119});
        clotheDict.Add("school", new List<int>() {3, 57, 5, 58, 59, 60, 61, 62, 40});
        clotheDict.Add("maid", new List<int>() {64, 65, 66, 67, 68, 69, 70, 71, 72});

        foreach (int layer in rightEyeDict.Values) {
            hideArtMesh(layer);
        }
        foreach (int layer in leftEyeDict.Values) {
            hideArtMesh(layer);
        }
        foreach (List<int> layers in hairDict.Values) {
            foreach (int layer in layers) {
                hideArtMesh(layer);
            }
        }
        foreach (List<int> layers in clotheDict.Values) {
            foreach (int layer in layers) {
                hideArtMesh(layer);
            }
        }

        setRightEyeColor(rightEyeColor);
        setLeftEyeColor(leftEyeColor);
        setHairName(hairName);
        setClotheName(clotheName);

        animator = GetComponent<Animator>();
        motionList = new List<string>(){
            "笑顔1", "笑顔2", "笑顔3", "照れる1", "驚く", "ルンルン", "照れ困", "得意げ"
        };
    }

    public void setRightEyeColor(string color)
    {
        if (!rightEyeDict.ContainsKey(color)) return;
        hideArtMesh(rightEyeDict[rightEyeColor]);
        showArtMesh(rightEyeDict[color]);
        rightEyeColor = color;
    }

    public void setLeftEyeColor(string color)
    {
        if (!leftEyeDict.ContainsKey(color)) return;
        hideArtMesh(leftEyeDict[leftEyeColor]);
        showArtMesh(leftEyeDict[color]);
        leftEyeColor = color;
    }

    public void setHairName(string name)
    {
        if (!hairDict.ContainsKey(name)) return;
        foreach (int layer in hairDict[hairName]) {
            hideArtMesh(layer);
        }
        foreach (int layer in hairDict[name]) {
            showArtMesh(layer);
        }
        hairName = name;
    }

    public void setClotheName(string name)
    {
        if (!clotheDict.ContainsKey(name)) return;
        foreach (int layer in clotheDict[clotheName]) {
            hideArtMesh(layer);
        }
        foreach (int layer in clotheDict[name]) {
            showArtMesh(layer);
        }
        clotheName = name;
    }

    private void hideArtMesh(int layer) 
    {
        var obj = transform.Find("Drawables/ArtMesh" + layer).gameObject;
        // obj.GetComponent<CubismRenderer>().Color = new Color(1f, 1f, 1f, 0f);
        obj.SetActive(false);
    }

    private void showArtMesh(int layer) 
    {
        var obj = transform.Find("Drawables/ArtMesh" + layer).gameObject;
        // obj.GetComponent<CubismRenderer>().Color = new Color(1f, 1f, 1f, 1f);
        obj.SetActive(true);
    }

    public void Action()
    {
        animator.Play(motionList[Random.Range(0, motionList.Count)]);
    }
}
