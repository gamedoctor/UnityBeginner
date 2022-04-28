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

            var character1 = new Character("フリオニール", 2, 3, 2, 1);
            var character2 = new Character("マリア", 1, 2, 2, 3);
            var character3 = new Character("ガイ", 2, 1, 3, 2);
            var character4 = new Character("レオンハルト", 3, 1, 2, 2);

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

            var weapon1 = new Weapon("ミスリルソード", WeaponType.Sword, 10);
            var weapon2 = new Weapon("銀の弓", WeaponType.Bow, 10);
            var weapon3 = new Weapon("バトルアクス", WeaponType.Axe, 10);
            var weapon4 = new Weapon("ロッド", WeaponType.Lod, 10);

            // パターン2
            // エクスカリバー 剣/50
            // よいちの矢 弓/45
            // ルーンアクス 斧/48
            // 賢者の杖 杖/40

            var weapon5 = new Weapon("エクスカリバー", WeaponType.Sword, 50);
            var weapon6 = new Weapon("よいちの矢", WeaponType.Bow, 45);
            var weapon7 = new Weapon("ルーンアクス", WeaponType.Axe, 48);
            var weapon8 = new Weapon("賢者の杖", WeaponType.Lod, 40);

            // それぞれのキャラクターが向いている装備と向いていない装備を
            // 1つずつ選出し、それぞれ何か表示されるように実装してください
            // パターン1とパターン2それぞれで表示すること

            // パターン1
            ConsoleResult(character1, new[] {weapon1, weapon2, weapon3, weapon4});
            ConsoleResult(character2, new[] {weapon1, weapon2, weapon3, weapon4});
            ConsoleResult(character3, new[] {weapon1, weapon2, weapon3, weapon4});
            ConsoleResult(character4, new[] {weapon1, weapon2, weapon3, weapon4});

            // パターン2
            ConsoleResult(character1, new[] {weapon5, weapon6, weapon7, weapon8});
            ConsoleResult(character2, new[] {weapon5, weapon6, weapon7, weapon8});
            ConsoleResult(character3, new[] {weapon5, weapon6, weapon7, weapon8});
            ConsoleResult(character4, new[] {weapon5, weapon6, weapon7, weapon8});
        }

        private void ConsoleResult(Character character, Weapon[] weapons)
        {
            ConsoleResult(character, weapons
                .Select(x => new WeaponSortResult(character, x, x.GetWeaponValue(character)))
                .OrderByDescending(x => x.value).ToArray());
        }

        private void ConsoleResult(Character character, WeaponSortResult[] weaponSortResults)
        {
            var index = 1;
            Debug.Log($"{character.name}が武器を装備した際に攻撃力が高い順");
            foreach (var sortResult in weaponSortResults)
            {
                Debug.Log($"{index}番目: {sortResult.weapon.name}, 攻撃力: {sortResult.value}");
                index++;
            }
        }

        public class WeaponSortResult
        {
            public Character character;
            public Weapon weapon;
            public int value;

            public WeaponSortResult(Character character, Weapon weapon, int value)
            {
                this.character = character;
                this.weapon = weapon;
                this.value = value;
            }
        }

        public class Character
        {
            public string name;
            public int power;
            public int speed;
            public int vital;
            public int magic;

            public Character(string name, int power, int speed, int vital, int magic)
            {
                this.name = name;
                this.power = power;
                this.speed = speed;
                this.vital = vital;
                this.magic = magic;
            }
        }

        public class Weapon
        {
            public string name;
            public WeaponType weaponType;
            public int value;

            public Weapon(string name, WeaponType weaponType, int value)
            {
                this.name = name;
                this.weaponType = weaponType;
                this.value = value;
            }

            public int GetWeaponValue(Character character)
            {
                return GetWeaponValue(character.power, character.speed, character.vital, character.magic);
            }

            public int GetWeaponValue(int power, int speed, int vital, int magic)
            {
                // 剣 力/4+武器攻撃力
                // 弓 力/2+速/2+武器攻撃力
                // 斧 力/2+体/2+武器攻撃力
                // 杖 魔/2+武器攻撃力
                switch (weaponType)
                {
                    case WeaponType.Sword:
                        return (int) ((float) power / 4 + value);
                    case WeaponType.Bow:
                        return (int) ((float) power / 2 + (float) speed / 2 + value);
                    case WeaponType.Axe:
                        return (int) ((float) power / 2 + (float) vital / 2 + value);
                    case WeaponType.Lod:
                        return (int) ((float) magic / 2 + value);
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public enum WeaponType
        {
            Sword,
            Bow,
            Axe,
            Lod,
        }
    }
}