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

            //ポケモンの定義
            var Pokemon1 = new Pokemon("ヒトカゲ", 39, 52, 43, 60, 50, 65);
            var Pokemon2 = new Pokemon("リザード", 58, 64, 58, 80, 65, 80);
            var Pokemon3 = new Pokemon("リザードン", 78, 84, 78, 109, 85, 100);
            var Pokemon4 = new Pokemon("ゼニガメ", 44, 48, 65, 50, 64, 43);
            var Pokemon5 = new Pokemon("カメール", 59, 63, 80, 65, 80, 58);
            var Pokemon6 = new Pokemon("カメックス", 79, 83, 100, 85, 105, 78);
            var Pokemon7 = new Pokemon("フシギダネ", 45, 49, 49, 65, 65, 45);
            var Pokemon8 = new Pokemon("フシギソウ", 60, 62, 63, 80, 80, 60);
            var Pokemon9 = new Pokemon("フシギバナ", 80, 82, 83, 100, 100, 80);

            //↓省略した配列の書き方
            Pokemon[] pokemons = StatusSortResult(new Pokemon[] { Pokemon1, Pokemon2, Pokemon3, Pokemon4, Pokemon5, Pokemon6, Pokemon7, Pokemon8, Pokemon9 }, Status.H);

            //↓配列の変数の作成
            //Pokemon[] pokemons

            //↓省略しない配列の書き方（基本形）　※覚える
            //Pokemon[] pokemons;
            //pokemons = new Pokemon[9];
            //pokemons[0] = Pokemon1;
            //pokemons[1] = Pokemon2;
            //pokemons[2] = Pokemon3;
            //pokemons[3] = Pokemon4;
            //pokemons[4] = Pokemon5;
            //pokemons[5] = Pokemon6;
            //pokemons[6] = Pokemon7;
            //pokemons[7] = Pokemon8;
            //pokemons[8] = Pokemon9;
        }

        //int[] values = new int[4]; ←int型の配列
        //int[] values = new int[]{ 0, 50, 21, 38 };

        //StatusSortResult(new Pokemon[9])

        //変数の名前は頭文字小文字が普通
        //void = 返り値無し
        //voidに型を入れると、その型を返す
        //プログラムは違う物に違う物を入れられないので、入れられるように変換してあげる
        public Pokemon[] StatusSortResult(Pokemon[] Pokemons,Status status)
        {
            List<Pokemon> pokemonlist = Pokemons.ToList();
            //List<Pokemon> pokemonlist = Pokemons.ToList();
            //　↑型　　　　↑リスト名　　↑対象　 ↑ToListでリストに変換して型を合わせる（リストに納められるようにする）
            //リスト型に変換

            //関数の末尾には（）が必要
            switch (status)
            {
                case Status.H:
                    //左がお皿 = 右が料理
                    Pokemons = pokemonlist.OrderByDescending(x => x.H).ToArray();
                    break;

                case Status.C:
                    break;

                case Status.S:
                    break;
            }
            return Pokemons;
        }

        //if文
        // == ←右と左が同じものだった場合、という意味
        //if(a == 3)
        //条件が合えばtrueになる

        //switch文
        //switch文はcaseを使うことができる
        //ただしcase内では計算ができない
        //switch(a)
        //switch文は文末にbreakを入れる

        //ポケモンのクラス
        public class Pokemon
        {
            public string name;
            public int H;
            public int A;
            public int B;
            public int C;
            public int D;
            public int S;

            //ポケモンのコンストラクタ
            public Pokemon(string name, int H, int A, int B, int C, int D, int S)
            {
                this.H = H;
                this.A = A;
                this.B = B;
                this.C = C;
                this.D = D;
                this.S = S;
            }
            //コンストラクタ = 初期化の時に使う関数
            //初期化とは、newで代入することを指す
        }

        public enum Status
        {
            H,
            A,
            B,
            C,
            D,
            S,
        }
    }
}