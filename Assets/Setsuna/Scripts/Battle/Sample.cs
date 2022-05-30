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
            Character[] characters = new Character[6];
            //-------------------------------------------------------------------------------
            // 課題.3
            // Characterを5人作成し、List型変数 characters に追加する
            // データは以下
            // アイク Lv.10, マルス Lv.15, ロイ Lv.5, エリウッド Lv.1, エフラム Lv.7, リン Lv12
            // 以下に答えを記載
            //-------------------------------------------------------------------------------
            var Character1 = new Character("アイク", 10);
            var Character2 = new Character("マルス", 15);
            var Character3 = new Character("ロイ", 5);
            var Character4 = new Character("エリウッド", 1);
            var Character5 = new Character("エフラム", 7);
            var Character6 = new Character("リン", 12);

            characters[0] = Character1;
            characters[1] = Character2;
            characters[2] = Character3;
            characters[3] = Character4;
            characters[4] = Character5;
            characters[5] = Character6;
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
            characters = characters.OrderByDescending(x => x.lv).ToArray();
            foreach (var Character in characters)
            {
                //string = 文字列
                string Logtext = Character.name;
                for (int i = 1; i <= 20; i++)
                {
                    if (Character.lv >= i)
                    {
                        Logtext += "★";
                    }
                    else
                    {
                        Logtext += "☆";
                    }
                }
                Debug.Log(Logtext);
            }
        }

        // 以下にクラスを記載する
        public class Character
        {
            public string name;
            public int lv;
            public Character(string name, int lv)
            {
                this.name = name;
                this.lv = lv;
            }
        }
    }
}