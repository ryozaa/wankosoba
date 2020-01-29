using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Live2D.Cubism.Core;
using Live2D.Cubism.Rendering;

// アニメーション一覧
// 通常 しょぼん ねむい ルンルン 疑問 驚く
// 照れる1 照れ困 笑顔1 笑顔2 笑顔3 得意げ 目そらし

public class ClosetSobako : MonoBehaviour
{
    public float posX;
    public float posY;
    private CubismModel model;
    private static string rightEyeColor = "green";
    private static string leftEyeColor = "green";
    private static string hairName = "hair_1";
    private static string clotheName = "clothes_1";
    private Dictionary<string, int> rightEyeDict;
    private Dictionary<string, int> leftEyeDict;
    private Dictionary<string, List<int>> hairDict;
    private Dictionary<string, List<int>> clotheDict;
    private Dictionary<string, string> descDict;
    private Animator animator;
    private List<string> motionList;

    void Start()
    {
        model = GetComponent<CubismModel>();

        rightEyeDict = new Dictionary<string, int>();
        rightEyeDict.Add("green", 27);
        rightEyeDict.Add("purple", 99);
        rightEyeDict.Add("pink", 100);
        rightEyeDict.Add("blue", 101);
        rightEyeDict.Add("skyblue", 102);
        rightEyeDict.Add("yellow", 103);
        rightEyeDict.Add("orange", 104);
        rightEyeDict.Add("red", 105);

        leftEyeDict = new Dictionary<string, int>();
        leftEyeDict.Add("green", 28);
        leftEyeDict.Add("purple", 91);
        leftEyeDict.Add("pink", 92);
        leftEyeDict.Add("blue", 93);
        leftEyeDict.Add("skyblue", 94);
        leftEyeDict.Add("yellow", 95);
        leftEyeDict.Add("orange", 96);
        leftEyeDict.Add("red", 97);

        hairDict = new Dictionary<string, List<int>>();
        hairDict.Add("hair_1", new List<int> { 31, 15, 35, 14, 16, 17 });
        hairDict.Add("hair_2", new List<int> { 31, 78, 109, 75, 83, 86 });
        hairDict.Add("hair_3", new List<int> { 31, 77, 110, 74, 82, 85 });
        hairDict.Add("hair_4", new List<int> { 31, 15, 111, 14, 16, 17 });
        hairDict.Add("hair_5", new List<int> { 107, 79, 111 });
        hairDict.Add("hair_6", new List<int> { 107, 79, 35 });
        hairDict.Add("hair_7", new List<int> { 107, 80, 111, 14 });
        hairDict.Add("hair_8", new List<int> { 31, 15, 115, 14, 16, 17, 89, 88, 36, 37 });
        hairDict.Add("hair_9", new List<int> { 31, 15, 115, 14, 16, 17, 89, 88, 12, 13 });
        hairDict.Add("hair_10", new List<int> { 31, 15, 115, 14, 16, 17, 89, 88, 10, 11 });
        hairDict.Add("hair_11", new List<int> { 31, 15, 115, 14, 16, 17, 116, 117, 10, 11 });
        hairDict.Add("hair_12", new List<int> { 31, 15, 111, 14, 16, 17, 116, 117, 10, 11 });
        hairDict.Add("hair_13", new List<int> { 107, 80, 106, 14, 90, 98 });

        clotheDict = new Dictionary<string, List<int>>();
        clotheDict.Add("clothes_1", new List<int> {42, 4, 44, 6, 7, 8, 9, 120, 121});
        clotheDict.Add("clothes_2", new List<int> {46, 47, 48, 49, 50, 51, 52, 118, 119});
        clotheDict.Add("clothes_3", new List<int> {38, 41, 43, 45, 53, 54, 55, 56, 63});
        clotheDict.Add("clothes_4", new List<int> {3, 57, 5, 58, 59, 60, 61, 62, 40});
        clotheDict.Add("clothes_5", new List<int> {64, 65, 66, 67, 68, 69, 70, 71, 72});
        clotheDict.Add("clothes_6", new List<int> {73, 76, 81, 84, 87, 180, 181, 182, 183});

        foreach (int layer in rightEyeDict.Values) {
            hideArtMesh(layer);
        }
        foreach (int layer in leftEyeDict.Values) {
            hideArtMesh(layer);
        }
        foreach (List<int> layers in hairDict.Values) {
            hideArtMesh(layers);
        }
        foreach (List<int> layers in clotheDict.Values) {
            hideArtMesh(layers);
        }

        setRightEyeColor(rightEyeColor);
        setLeftEyeColor(leftEyeColor);
        setHairName(hairName);
        setClotheName(clotheName);

        animator = GetComponent<Animator>();
        motionList = new List<string>(){
            "笑顔1", "笑顔2", "笑顔3", "照れる1", "驚く", "ルンルン", "照れ困", "得意げ"
        };

        Invoke("move", 0.2f);
    }

    private void move()
    {
        transform.position = new Vector3(posX, posY, 0);
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
        hideArtMesh(hairDict[hairName]);
        showArtMesh(hairDict[name]);
        hairName = name;
    }

    public void setClotheName(string name)
    {
        if (!clotheDict.ContainsKey(name)) return;
        hideArtMesh(clotheDict[clotheName]);
        showArtMesh(clotheDict[name]);
        clotheName = name;
    }

    private void hideArtMesh(int layer)
    {
        var obj = model.Drawables.FindById("ArtMesh" + layer);
        obj.gameObject.GetComponent<CubismRenderer>().Color = new Color(1f, 1f, 1f, 0f);
    }

    private void hideArtMesh(List<int> layers)
    {
        foreach (int layer in layers) {
            hideArtMesh(layer);
        }
    }

    private void showArtMesh(int layer) 
    {
        var obj = model.Drawables.FindById("ArtMesh" + layer);
        obj.gameObject.GetComponent<CubismRenderer>().Color = new Color(1f, 1f, 1f, 1f);
    }

    private void showArtMesh(List<int> layers)
    {
        foreach (int layer in layers) {
            showArtMesh(layer);
        }
    }

    public void Action()
    {
        var anim = motionList[Random.Range(0, motionList.Count)];
        Debug.Log(anim);
        animator.Play(anim);
    }
}
