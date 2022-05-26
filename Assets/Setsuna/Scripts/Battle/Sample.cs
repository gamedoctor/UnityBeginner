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
            // 課題:
            // 以下のグループが存在する
            // 剣: どうのつるぎ, はがねのつるぎ, ロトのつるぎ
            // 斧: どうのおの, はがねのおの, まじんのオノ
            // 槍: たけやり, はがねのやり, はぐれメタルのやり
            // 
            // 武器というカテゴリに全てのアイテムが入っており、さらに以下のように分類される
            // 非売品: ロトのつるぎ, まじんのオノ, はぐれメタルの槍
            // 販売品: その他全て
            //
            // 武器というくくりの配列(剣, 斧, 槍)をそれぞれグループ毎に振り分け、
            // その上で販売品・非売品の分類にさらに分けてそれぞれ表示させよ
            // また販売品は緑文字、非売品は赤文字で名前を表示すること、そしてカンマ区切りの1行でそれぞれ表示せよ
            // (例) Debug.Log("武器種剣　販売品: A,B 非売品: C");　※種類毎にはLog出力はわけてOK
            // 
            // また予め剣・斧・槍もしくは販売品・非売品などでListをわけることは禁止で、必ずひとつのListから始めること
            // 結果が複数のListになることは許容するが、最大3つまでとする

            var weapon1 = new weapon("どうのつるぎ", weapon.weapontype.sword, true);
            var weapon2 = new weapon("はがねのつるぎ", weapon.weapontype.sword, true);
            var weapon3 = new weapon("ロトのつるぎ", weapon.weapontype.sword, false);
            var weapon4 = new weapon("どうのおの", weapon.weapontype.axe, true);
            var weapon5 = new weapon("はがねのおの", weapon.weapontype.axe, true);
            var weapon6 = new weapon("まじんのオノ", weapon.weapontype.axe, false);
            var weapon7 = new weapon("たけやり", weapon.weapontype.spear, true);
            var weapon8 = new weapon("はがねのやり", weapon.weapontype.spear, true);
            var weapon9 = new weapon("はぐれメタルのやり", weapon.weapontype.spear, false);

            weapon[] weapons = new weapon[] { weapon1, weapon2, weapon3, weapon4, weapon5, weapon6, weapon7, weapon8, weapon9 };

            result(weapons, weapon.weapontype.spear);
        }

        public void result(weapon[] allweapon, weapon.weapontype weapontype)
        {
            for (int i = 0; i < allweapon.Length; i++)
            {
                if (allweapon[i].sale == true)
                {
                    if (allweapon[i].type == weapontype)
                    {
                        Debug.Log(allweapon[i].name);
                    }
                    //Debug.Log(allweapon[i].name);
                }
                //Debug.Log(allweapon[i].name);
            }
        }


    public class weapons
    {
        public void Notforsaleinsowrd()
        {
            Debug.Log("武器種剣　販売品：<color=green>weapon1,weapon2<color>　非売品：<color=red>weapon3<color>");
        }
            
    }
    




        public class weapon
        {
            public string name;
            public weapontype type;
            public bool sale;
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="name">武器の名前</param>
            /// <param name="type">武器の種類</param>
            public weapon(string name, weapontype type, bool sale)
                //        ↑これ、あとで消えてしまうから
                //      ↓コンストラクタで変数に代入する
            {
                this.name = name;
                this.type = type;
                this.sale = sale;
            }

            public enum weapontype
            {
                /// <summary>
                /// 剣
                /// </summary>
                sword,
                /// <summary>
                /// 槍
                /// </summary>
                spear,
                /// <summary>
                /// 斧
                /// </summary>
                axe,
            }
            //イーナム型は便利。コーキーさんはイーナム型が大好き
            //スラッシュ三つでサマリーを設定できる。未来の自分に優しくしてあげよう

        }
    }
}