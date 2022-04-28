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
            // 剣 「力/4」+「武器攻撃力」
            // 弓 「力/2」+「速/2」+「武器攻撃力」
            // 斧 「力/2」+「体/2」+「武器攻撃力」
            // 杖 「魔/2」+「武器攻撃力」
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


            var party = new Party();

            var character1 = new CharacterBase("フリオニール",2,3,2,1);
            var character2 = new CharacterBase("マリア",1,2,2,3);
            var character3 = new CharacterBase("ガイ",2,1,3,2);
            var character4 = new CharacterBase("レオンハルト",3,1,2,2);

            party.AddCharacter(character1);
            party.AddCharacter(character2);
            party.AddCharacter(character3);
            party.AddCharacter(character4);

            var sword1 = new Sword("ミスリルソード", (int)10);
            var bow1 = new Bow("銀の弓", (int)10);
            var axe1 = new Axe("バトルアクス", (int)10);
            var wand1 = new Wand("ロッド", (int)10);

            var sword2 = new Sword("エクスカリバー", (int)50);
            var bow2 = new Bow("よいちの矢", (int)45);
            var axe2 = new Axe("ルーンアクス", (int)48);
            var wand2 = new Wand("賢者の杖", (int)40);            

            party.AddWeapon(sword1);
            party.AddWeapon(bow1);
            party.AddWeapon(axe1);
            party.AddWeapon(wand1);


            // それぞれのキャラクターが向いている装備と向いていない装備を
            // 1つずつ選出し、それぞれ何か表示されるように実装してください
            // パターン1とパターン2それぞれで表示すること
            



        }
            /// <summary>
            /// キャラクターや武器の情報を持つクラス
            /// </summary>
            public class Party
            {
                //キャラのパーティと武器のリスト
                public List<CharacterBase> characters = new List<CharacterBase>();
                public List<WeaponBase> weapons = new List<WeaponBase>();

                

                public void AddCharacter(CharacterBase chara)
                {
                    characters.Add(chara);
                }

                public void AddWeapon(WeaponBase weapon)
                {
                    weapons.Add(weapon);
                }

                //キャラごとの武器の相性を返す関数
                public CharaCompatibility Execute()
                {
                    //キャラと武器毎の相性の値を纏めたリストを配列化させて返す
                    var wea = weapons;



                    var chara = characters.Select(x=>new CharaCompatibility{charaname = x.name});

                    for (int i = 0; i < wea.Count; i++)
                    {
                         = wea[i].GetCompatibility(characters[i]);
                    }
                    return ;


                }

            }

            public class WeaponCompatibility
            {
                string weaponname;

                int compatibility;
            }

            public class CharaCompatibility
            {
                public string charaname;

                public WeaponCompatibility[] compati;
            }

            /// <summary>
            /// キャラクターベース
            /// </summary>
            public class CharacterBase
            {
                // パラメータは左から 力/速/体/魔

                public string name;
                public int strength;
                public int speed;
                public int physical;
                public int magical;
                public CharacterBase(string name, int strength, int speed, int physical, int magical)
                {
                    this.name = name;
                    this.strength = strength;
                    this.speed = speed;
                    this.physical = physical;
                    this.magical = magical;
                }

            }

            /// <summary>
            /// 剣「力/4」+「武器攻撃力」
            /// </summary>
            public class Sword : WeaponBase
            {
                //public override
                public Sword(string name , int weaponPower): base (name, weaponPower)
                {
                    
                }

                public override int GetCompatibility(CharacterBase character)
                {
                    var compatibility = (character.strength / 4) + weaponPower;
                    return compatibility;
                }
            }

            /// <summary>
            /// 弓 「力/2」+「速/2」+「武器攻撃力」
            /// </summary>
            public class Bow : WeaponBase
            {
                //public override
                public Bow(string name , int weaponPower): base (name, weaponPower)
                {
                    
                }

                public override int GetCompatibility(CharacterBase character)
                {
                    var compatibility = (character.strength / 2) + (character.speed / 2) + weaponPower;
                    return compatibility;
                }

            }
            
            /// <summary>
            /// 斧 「力/2」+「体/2」+「武器攻撃力」
            /// </summary>
            public class Axe : WeaponBase
            {
                //public override
                public Axe(string name, int weaponPower): base (name, weaponPower)
                {
                    
                }
                public override int GetCompatibility(CharacterBase character)
                {
                    var compatibility = (character.strength / 2)+(character.physical / 2) + weaponPower;
                    return compatibility;
                }
            }

            /// <summary>
            /// 杖「魔/2」+「武器攻撃力」
            /// </summary>
            public class Wand : WeaponBase
            {
                //public override
                public Wand(string name , int weaponPower ): base (name, weaponPower)
                {

                }
                public override int GetCompatibility(CharacterBase character)
                {
                    var compatibility = (character.magical / 2) + weaponPower;
                    return compatibility;
                }
            }


            /// <summary>
            /// 武器継承元
            /// </summary>
            public class WeaponBase
            {
                public string name;
                public int weaponPower;

                public WeaponBase(string name, int weaponPower)
                {}
                
                // 相性の値を出す
                public virtual int GetCompatibility(CharacterBase character)
                {
                    throw new NotImplementedException();
                }
            }


    }
}