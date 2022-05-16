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
            // 以下のポケモンが存在する
            // ヒトカゲ、リザード、リザードン
            // ゼニガメ、カメール、カメックス
            // フシギダネ、フシギソウ、フシギバナ
            //
            // それぞれのポケモンの種族値を表示する仕組みを作成する。
            // その場合、それぞれの種族値のHPが高い順、特攻が高い順、素早さが低い順の3つの結果を表示させよ。
            // 表示させる場合は「カメックス HP/攻撃/防御/特攻/特防/素早さ」で数値を表示させること。
            // またソート対象のものは赤色でパラメータを表示させること
            // 赤くする場合は以下のように記述すればできる
            // Debug.Log("<color=red>あああ</color>");
            //
            // 種族値は実際のポケモンの数値を参照する。

            var monsters = new List<Monster>
            {
                new Monster("ヒトカゲ", 39, 52, 43, 60, 50, 65),
                new Monster("リザード", 58, 64, 58, 80, 65, 80),
                new Monster("リザードン", 78, 84, 78, 109, 85, 100),
                new Monster("ゼニガメ", 44, 48, 65, 50, 64, 43),
                new Monster("カメール", 59, 63, 80, 65, 80, 58),
                new Monster("カメックス", 79, 83, 100, 85, 105, 78),
                new Monster("フシギダネ", 45, 49, 49, 65, 65, 45),
                new Monster("フシギソウ", 60, 62, 63, 80, 80, 60),
                new Monster("フシギバナ", 80, 82, 83, 100, 100, 80),
            };

            ConsoleMonsters(
                monsters.OrderByDescending(v => v.h),
                (monster) =>
                    $"{monster.name}　<color=red>{monster.h}</color>/{monster.a}/{monster.b}/{monster.c}/{monster.d}/{monster.s}"
            );

            ConsoleMonsters(
                monsters.OrderByDescending(v => v.c),
                (monster) =>
                    $"{monster.name}　{monster.h}/{monster.a}/{monster.b}/<color=red>{monster.c}</color>/{monster.d}/{monster.s}"
            );

            ConsoleMonsters(
                monsters.OrderByDescending(v => v.s),
                (monster) =>
                    $"{monster.name}　{monster.h}/{monster.a}/{monster.b}/{monster.c}/{monster.d}/<color=red>{monster.s}</color>"
            );
        }

        private void ConsoleMonsters(IEnumerable<Monster> monsters, Func<Monster, string> onEvent)
        {
            foreach (var monster in monsters)
            {
                Debug.Log(onEvent(monster));
            }
        }

        public class Monster
        {
            public string name;
            public int h;
            public int a;
            public int b;
            public int c;
            public int d;
            public int s;

            public Monster(string name, int hitPoint, int pAttack, int pDefense, int sAttack, int sDefence, int speed)
            {
                this.name = name;
                h = hitPoint;
                a = pAttack;
                b = pDefense;
                c = sAttack;
                d = sDefence;
                s = speed;
            }
        }
    }
}