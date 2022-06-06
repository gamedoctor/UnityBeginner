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
            // 課題
            // 以下のデータ群が存在する
            var swords = new List<Sword>
            {
                new Sword {name = "聖剣エクスカリバー", value = 100},
                new Sword {name = "ロングソード", value = 50},
                new Sword {name = "魔剣グラム", value = 75},
                new Sword {name = "聖剣クラウソラス", value = 90},
                new Sword {name = "ドンパッチソード", value = 1},
                new Sword {name = "竹刀", value = 10},
                new Sword {name = "木刀", value = 20},
                new Sword {name = "愛の剣", value = 80},
                new Sword {name = "名刀正宗", value = 85},
                new Sword {name = "トゥハンデッドソード", value = 65},
                new Sword {name = "デスブリンガー", value = 64},
                new Sword {name = "トロの剣", value = 98},
                new Sword {name = "釘バット", value = 67},
                new Sword {name = "ラストフェンサー", value = 62},
                new Sword {name = "ハリセン", value = 5},
                new Sword {name = "撲殺人参ソード", value = 35},
            };

            // 問.1
            // それぞれ名前に「剣」「ソード」「刀」それぞれが含まれる、もしくはいずれも含まれない配列データを作成し、
            // 「剣」「ソード」「刀」「それ以外」の順番の上でvalueの値でソートした結果を出力せよ
            var KEN = swords.Where(x => x.name != null && swords.Any(X => x.name.Contains("剣")))
            .OrderByDescending(x => x.value)
            .ToArray();
            for (int i = 0; i < KEN.Count(); i++)
            {
                Debug.Log(KEN[i].name);
            }

            var SODO = swords.Where(x => x.name != null && swords.Any(X => x.name.Contains("ソード")))
            .OrderByDescending(x => x.value)
            .ToArray();
            for (int i = 0; i < SODO.Count(); i++)
            {
                Debug.Log(SODO[i].name);
            }

            var KATANA = swords.Where(x => x.name != null && swords.Any(X => x.name.Contains("刀")))
            .OrderByDescending(x => x.value)
            .ToArray();
            for (int i = 0; i < KATANA.Count(); i++)
            {
                Debug.Log(KATANA[i].name);
            }
            
            var SOREIGAI = swords.Where(x => x.name != null && swords.Any(X => !x.name.Contains("剣") && !x.name.Contains("ソード")&& !x.name.Contains("刀")))
            .OrderByDescending(x => x.value)
            .ToArray();
            for (int i = 0; i < SOREIGAI.Count(); i++)
            {
                Debug.Log(SOREIGAI[i].name);
            }

            // 問.2
            // それぞれ種別に分けた剣をSwordGroupというクラスに代入せよ
            // SwordGroupは4つ準備することを想定する
            SwordGroup KENgroup = new SwordGroup();
            SwordGroup SODOgroup = new SwordGroup();
            SwordGroup KATANAgroup = new SwordGroup();
            SwordGroup SOREIGAIgroup = new SwordGroup();

            KENgroup.swords = KEN;
            SODOgroup.swords = SODO;
            KATANAgroup.swords = KATANA;
            SOREIGAIgroup.swords = SOREIGAI;

            // 問.3
            // 分けたSwordGroupをSelectManyを利用し、valueが70以上のデータを取得せよ
            // この時に利用するLinq文は1つまでとし、複数の変数を用意してはならない
            // ※チェーンメソッドであれば個数に制限はしない、複数のLinq用の変数を用意することが禁止で1つの変数でこなすこと
            // 例) values.Select(...).Where(...) のように複数使うことは問題ない
            // 例) values1.Select(...) values2.Select(...)のように複数の変数を用意して行うことは禁止
            SwordGroup[] sGroup = new SwordGroup[]{KENgroup,SODOgroup,KATANAgroup,SOREIGAIgroup};

            List<Sword> results = sGroup.SelectMany(x =>x.swords).Where(x => x.value >= 70).ToList();
            
            for (int i = 0; i < results.Count; i++)
            {
                Debug.Log($"{results[i].name},{results[i].value}");
            }


        }


        public class Sword
        {
            public string name;
            public int value;
            public string[] relatedSwordNames;
        }

        public class SwordGroup
        {
            public Sword[] swords;
        }
    }
}