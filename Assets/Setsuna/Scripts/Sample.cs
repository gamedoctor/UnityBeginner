using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        public void Start()
        {
            string text1 = "グラン";
            string text2 = "リオン";

            // 課題.1
            // test1とtext2と"ド"を結合し、グランドリオンという文字列を完成させよ

            string completetext1 = text1 + "ド" + text2;
            Debug.Log(completetext1);

            // 課題.2
            // 課題.1の文字からンという文字を削除し、グラドリオにせよ

            string completetext2 = completetext1.Replace("ン","");
            Debug.Log(completetext2);

            // 課題.3
            // 課題.2の文字をグラという文字をドーという文字に置き換え、ドードリオに変換せよ

            string completetext3 = completetext2.Replace("グラ", "ドー");
            Debug.Log(completetext3);

            // 課題.4
            // 課題.1と課題.3の結果を結合し、それぞれの文字数が何回出力されているか表示せよ
            // 登場しない文字については表示する必要はない
            // 例) ド 1回, ー 1回 など

            //Dictionary<string, int> resultMap = new Dictionary<string, int>();
            //for (var i = 0; i < 文字列の長さ; i++)
            //{
            //    ※ substringを利用する
            //    ※ Dictionaryに存在していなければキーを追加する
            //    ※ 該当キーのもののカウントを追加する
            //}

            string completetext4 = completetext1 + completetext3;
            int completetext4indo;
            int completetext4inno;
            for (int i = 0; i < completetext4.Length; i++)
            {
                if (completetext4.Contains("ド"))
                {
                    int completetext4indo + 1;
                }
                if (completetext4.Contains("ー"))
                {
                    int completetext4inno + 1;
                }
            }
            Debug.Log("ド",completetext4indo, "回、ー" completetexrt4inno,"回");
        }
    }
}