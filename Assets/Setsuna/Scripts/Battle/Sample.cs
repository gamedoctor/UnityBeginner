using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Setsuna
{
    public class Sample : MonoBehaviour
    {
        public void Start()
        {
            // 課題.1
            // クラス名 Character を作成する
            // 要素は string型変数 name int型変数 lv を持つ
            // 以下に答えを記載
            //-------------------------------------------------------------------------------


            //-------------------------------------------------------------------------------
            // 課題.2
            // List型変数 characters を作る
            // 配列はこの時点ではなし
            // 以下に答えを記載
            //-------------------------------------------------------------------------------
            var characters = new List<Character>();

            //-------------------------------------------------------------------------------
            // 課題.3
            // Characterを5人作成し、List型変数 characters に追加する
            // データは以下
            // アイク Lv.10, マルス Lv.15, ロイ Lv.5, エリウッド Lv.1, エフラム Lv.7, リン Lv12
            // 以下に答えを記載
            //-------------------------------------------------------------------------------
            characters.Add(new Character {name = "アイク", lv = 10});
            characters.Add(new Character {name = "マルス", lv = 15});
            characters.Add(new Character {name = "ロイ", lv = 5});
            characters.Add(new Character {name = "エリウッド", lv = 1});
            characters.Add(new Character {name = "エフラム", lv = 7});
            characters.Add(new Character {name = "リン", lv = 12});

            //-------------------------------------------------------------------------------
            // 課題.4
            // Debug.Log でキャラの情報を表示させる
            // 以下のようなルールで表示すること
            // 例) アイク Lv.5の場合は以下
            // アイク ★★★★★☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            // Lvの数だけ★で埋める、レベルは最大20として足りていない部分は☆で埋めること
            // 表示する場合、キャラクターのレベルが高い順で表示させること
            // 以下に答えを記載
            //-------------------------------------------------------------------------------
            var results = characters
                .OrderByDescending(v => v.lv)
                .Select(v => $"{v.name} " + string.Join("", new int[20].Select((_, i) => v.lv > i ? "★" : "☆")));
            foreach (var result in results)
            {
                Debug.Log(result);
            }
        }

        // 以下にクラスを記載する
        public class Character
        {
            public string name;
            public int lv;
        }
    }
}