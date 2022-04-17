using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Days : MonoBehaviour
{
    private GameObject score_object; // Textオブジェクト

    void Start()
    {
        score_object = GameObject.Find("re_days");
    }
    void Rewrite(int days)
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "あと" + days + "日";
    }
}
