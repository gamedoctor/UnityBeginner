using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Setsuna
{
    public class Sample : MonoBehaviour
    {

        public const int MAX_LEVEL = 20;

        public void Start()
        {
            // 課題.1
            // クラス名 Character を作成する
            // 要素は string型変数 name int型変数 lv を持つ
            // 「//以下にクラスを記載する」の下に答えを記載
            //-------------------------------------------------------------------------------
            
            //-------------------------------------------------------------------------------
            // 課題.2
            // List型変数 characters を作る
            // 配列はこの時点ではなし
            // 以下に答えを記載
            //-------------------------------------------------------------------------------
            List<Character> characters = new List<Character>();
            //-------------------------------------------------------------------------------
            // 課題.3
            // Characterを5人作成し、List型変数 characters に追加する
            // データは以下
            // アイク Lv.10, マルス Lv.15, ロイ Lv.5, エリウッド Lv.1, エフラム Lv.7, リン Lv12
            // 以下に答えを記載
            //-------------------------------------------------------------------------------
            Character Ike = new Character("アイク", 10);
            Character Mars = new Character("マルス", 15);
            Character Roy = new Character("ロイ", 5);
            Character Eliwood = new Character("エリウッド", 1);
            Character Efram = new Character("エフラム", 7);
            Character Rin = new Character("リン", 12);

            characters.Add(Ike);
            characters.Add(Mars);
            characters.Add(Roy);
            characters.Add(Eliwood);
            characters.Add(Efram);
            characters.Add(Rin);

            characters = characters.OrderByDescending(x => x.lv).ToList();
            //-------------------------------------------------------------------------------
            // 課題.4
            // Debug.Log でキャラの情報を表示させる
            // 以下のようなルールで表示すること
            // 例) アイク Lv.5の場合は以下
            // アイク ★★★★★☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            // Lvの数だけ★で埋める、レベルは最大20として足りていない部分は☆で埋めること
            // 表示する場合、キャラクターのレベルが高い順で表示させること
            // foreach, while, for, do禁止、Linqのみで実現
            // 以下に答えを記載
            //-------------------------------------------------------------------------------
            
        
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