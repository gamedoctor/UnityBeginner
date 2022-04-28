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
            // キャラクターが4人います
            // パラメータは左から 力/速/体/魔
            // フリオニール 2/3/2/1
            // マリア 1/2/2/3
            // ガイ 2/1/3/2
            // レオンハルト 3/1/2/2
            //
            // 以下の武器種類があります
            // 剣 力/4+武器攻撃力
            // 弓 力/2+速/2+武器攻撃力
            // 斧 力/2+体/2+武器攻撃力
            // 杖 魔/2+武器攻撃力
            //
            // 以下のアイテムが存在しています
            // パラメータから左から 種類/威力
            // パターン1
            // ミスリルソード 剣/10
            // 銀の弓 弓/10
            // バトルアクス 斧/10
            // ロッド 杖/10
            //
            // パターン2
            // エクスカリバー 剣/50
            // よいちの矢 弓/45
            // ルーンアクス 斧/48
            // 賢者の杖 杖/40
            //
            // それぞれのキャラクターが向いている装備と向いていない装備を
            // 1つずつ選出し、それぞれ何か表示されるように実装してください
            // パターン1とパターン2それぞれで表示すること


            var character1 = new character("フリオニール", 0, 2, 3, 2, 1);
            var character2 = new character("マリア", 0, 1, 2, 2, 3,);
            var character3 = new character("ガイ", 0, 2, 1, 3, 2,);
            var character4 = new character("レオンハルト", 0, 3, 1, 2, 2,);

            var weapon1 = new sword("ミスリルソード", 50);
            var weapon2 = new bow("銀の弓", 10);
            var weapon3 = new axe("バトルアクス", 10);
            var weapon4 = new wand("ロッド", 10);

            var weapon5 = new sword("エクスカリバー", 50);
            var weapon6 = new bow("よいちの矢", 45);
            var weapon7 = new axe("ルーンアクス", 48);
            var weapon8 = new wand("賢者の杖", 40);

            //キャラクタークラスの作成
            public class character
            {
                public string name;
                public int weponpower;
                public int power;
                public int speed;
                public int physical;
                public int magical;
            }

            \public class weapon
            {
                public string name;
                public int weaponpower;
            }

            //剣クラス
            public class sword : weapon
            {
                public int power +4;
            }
            
            //弓クラス
            public class bow : weapon
            {
                public int power +2;
                public int speed +2;
            }
            
            //斧クラス
            public class axe : weapon
            {
                public int power +2;
                public int physical +2;
            }
            
            //杖クラス
            public class wand : weapon
            {
                public int magical +2;
            }


            public class pattern1
            {
                public weapon1
            }

            public class topstatus
            {
                public int(int power,int speed,int physical,int magical);
                    .Select(x => new characterpower)
                    .OrderByDescending(x => x.score)
                    .ToArray();
            }

            public class StatusResult
            {
                public int power(character + weapon)
                public int speed(character + weapon)
                public int physical(character + weapon)
                public int magical(character + weapon)
            }


            public class Characterpower
            {
                public virtual StatusResult[] GetStatusResult
                {
                    return 
                }
            }
            
            foreach (var StatusResult in weapon.Take(1))
            {
                Debug.Log($"{step},{statusResult.character.name},{statusResult.weapon.name}");
                stepp++
            }

        }
    }
}