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
            // ※上記のようなログの出し方をしたい場合は、出力用のstring型変数を用意すると解決する
            // 販売品A,Bが入るstring型変数と、非売品Cが入る変数を用意しよう
            //
            // また予め剣・斧・槍もしくは販売品・非売品などでListをわけることは禁止で、必ずひとつのListから始めること
            // 結果が複数のListになることは許容するが、最大3つまでとする
            // ※関数の中で一時変数としてリストを作れば丸いかもしれない

            List<WeaponBase> weaponlist = new List<WeaponBase>();

            Sword bronzesword = new Sword(name = "どうのつるぎ");
            Sword ironsword = new Sword(name = "はがねのつるぎ");
            Sword swordofROTO = new Sword(name = "ロトのつるぎ");
            Axe bronzeaxe = new Axe(name = "どうのおの");
            Axe ironaxe = new Axe(name = "はがねのおの");
            Axe axeofDEVIL = new Axe(name = "まじんのおの");
            Spear bamboospear = new Spear(name = "たけやり");
            Spear ironspear = new Spear(name = "はがねのやり");
            Spear spearofLoneMetalSlime = new Spear(name = "はぐれメタルのやり");

            weaponlist.Add(bronzesword);
            weaponlist.Add(ironsword);
            weaponlist.Add(swordofROTO);
            weaponlist.Add(bronzeaxe);
            weaponlist.Add(ironaxe);
            weaponlist.Add(axeofDEVIL);
            weaponlist.Add(bamboospear);
            weaponlist.Add(ironspear);
            weaponlist.Add(spearofLoneMetalSlime);

        }

        public class WeaponBase
        {
            public string name;
            
            public WeaponBase(string name)
            {
                this.name = name;
            }
        }


        public class Sword : WeaponBase
        {
            public Sword(string name) :base (name) {}
        }

        public class Axe : WeaponBase
        {
            public Axe(string name) :base (name) {}
        }

        public class Spear : WeaponBase
        {
            public Spear(string name) :base (name) {}
        }

        public class Name
        {
            int aaaa;
            
        }


    }
}