using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Networking;

// アニメーション一覧
// 通常 しょぼん ねむい ルンルン 疑問 驚く
// 照れる1 照れ困 笑顔1 笑顔2 笑顔3 得意げ 目そらし

public class HomeSobako : MonoBehaviour
{
    public Button button;
    public Text text;
    public SliderManager sliderManager;
    public MenuManager menuManager;
    public Animator frameAnimator;
    public Text nameFrame;
    private Animator animator;
    private Dictionary<string, string> textDict;

    void Start()
    {
        animator = GetComponent<Animator>();
        nameFrame.text = PlayerPrefs.GetString("CHARACTER_NAME", "そばこ");

        textDict = new Dictionary<string, string>();
        textDict.Add("どうかしましたか？", "疑問");
        textDict.Add("なんですか？", "疑問");
        textDict.Add("わっ！びっくりしました……", "驚く");
        textDict.Add("っ！な、なにも隠してないですよー", "目そらし");
        textDict.Add("あ、あんまり見られると照れちゃいます……", "照れ困");
        textDict.Add("実は食べ物の中で一番そばが好きなんです！", "笑顔2");
        textDict.Add("マスターは動物好きですか？いつかモフモフのワンちゃんに触ってみたいなぁ", "笑顔3");
        textDict.Add("今日は髪型がうまくまとまらなくて……もしかしていつもと同じだと思ってませんか？", "しょぼん");
        textDict.Add("いつでも笑顔！を心がけてるんですよ♪", "笑顔1");
        textDict.Add("えへへ♪マスターとたくさんお話できてうれしいです！", "笑顔2");
        textDict.Add("今日もたくさんいい事があるといいですね！", "笑顔3");
        textDict.Add("音楽を聴くとつい踊りたくなっちゃいます♪", "ルンルン");
        textDict.Add("明日はなにをしようかな～？", "ルンルン");

        foreach (var data in TodoTable.FindAll().Rows) {
            if ((int)data["status"] == 0) {
                textDict.Add($"『{(string)data["title"]}』はもう終わりましたか？", "笑顔1");
            }
        }

        var date = DateTime.Now;
        foreach (var data in ScheduleTable.FindByDate(date.ToString("yyyy-MM-dd")).Rows) {
            textDict.Add($"今日は『{(string)data["title"]}』の予定がありますよ！", "笑顔1");
        }
        date.AddDays(1);
        foreach (var data in ScheduleTable.FindByDate(date.ToString("yyyy-MM-dd")).Rows) {
            textDict.Add($"明日は『{(string)data["title"]}』の予定がありますよ！", "笑顔1");
        }
        StartCoroutine(Test());
    }

    public void OnMouseDown() 
    {
        sliderManager.UnSelectAll();
        menuManager.Close();

        frameAnimator.Play("Frame", -1, 0);
        
        int rand = UnityEngine.Random.Range(0, textDict.Count);
        text.text = textDict.Keys.ElementAt(rand);
        animator.Play(textDict.Values.ElementAt(rand));
    }

    private IEnumerator Test()
    {
        string url = "https://ja.wikipedia.org/w/api.php?action=query&format=json&formatversion=2&prop=extracts&exlimit=1&explaintext&titles=";
        url += UnityWebRequest.EscapeURL(DateTime.Now.ToString("M月d日"));

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError) {
            Debug.Log(request.error);
        }
        else if (request.responseCode == 200) {
            string data = request.downloadHandler.text;
            int index = data.IndexOf("== 記念日・年中行事 ==");

            if (index > 0) {
                data = data.Substring(index + 16);

                index = data.IndexOf("\\n\\n\\n==");
                data = data.Substring(0, index);

                foreach (string v in data.Split(new string[] { "\\n" }, System.StringSplitOptions.None)) {
                    index = v.IndexOf("の日（ 日本）");
                    if (index > 0) {
                        string message = "今日は" + v.Substring(0, index + 2) + "ですよ！";
                        textDict.Add(message, "得意げ");
                    }
                }
            }
        }
    }
}
