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

            PokemonBase hitokage = new PokemonBase("ヒトカゲ", 39, 52, 43, 60, 50, 65);
            PokemonBase rizard = new PokemonBase("リザード", 58, 64, 58, 80, 65, 80);
            PokemonBase rizardon = new PokemonBase("リザードン", 78, 84, 78, 109, 85, 100);
            PokemonBase zenigame = new PokemonBase("ゼニガメ", 44, 48, 65, 50, 64, 43);
            PokemonBase kamail = new PokemonBase("カメール", 59, 63, 80, 65, 80, 58);
            PokemonBase kamex = new PokemonBase("カメックス", 79, 83, 100, 85, 105, 78);
            PokemonBase husigidane = new PokemonBase("フシギダネ", 45, 49, 49, 65, 65, 45);
            PokemonBase husigisou = new PokemonBase("フシギソウ", 60, 62, 63, 80, 80, 60);
            PokemonBase husigibana = new PokemonBase("フシギバナ", 80, 82, 83, 100, 100, 80);

            PokemonList pokelib = new PokemonList();

            pokelib.Add(hitokage);
            pokelib.Add(rizard);
            pokelib.Add(rizardon);
            pokelib.Add(zenigame);
            pokelib.Add(kamail);
            pokelib.Add(kamex);
            pokelib.Add(husigidane);
            pokelib.Add(husigisou);
            pokelib.Add(husigibana);

            HpDescendSort(pokelib.pokemons);

        }

        /// <summary>
        /// ポケモンの情報を持つクラス
        /// </summary>
        public class PokemonBase
        {
            public string name;
            public int hp;
            public int atk;
            public int def;
            public int exatk;
            public int exdef;
            public int spd;

            public PokemonBase(string name ,int hp, int atk, int def, int exatk, int exdef, int spd)
            {
                this.name = name;
                this.hp = hp;
                this.atk = atk;
                this.def = def;
                this.exatk = exatk;
                this.exdef = exdef;
                this.spd = spd;
            }
        }

        public class PokemonList
        {
            public List<PokemonBase> pokemons = new List<PokemonBase>();

            public void Add(PokemonBase pokemon)
            {
                pokemons.Add(pokemon);
            }
        }

        //テスト用にソートベースの外で実験
        public void HpDescendSort(List<PokemonBase> pokemonList)
        {
            //問題の個所、何故ダメなのかよく分からない
            pokemonList = pokemonList.OrderByDescending(x=> x.hp);

            foreach (var item in pokemonList)
            {
                Debug.Log($"{item.name}  {item.hp}  {item.atk}  {item.def}  {item.exatk}  {item.exdef}  {item.spd}");
            }
        }

        /// <summary>
        /// ポケモンのステータスをソートする関数を持つクラス
        /// </summary>
        public class SortBase
        {
            /// <summary>
            /// HPを降順にソート
            /// </summary>


            /// <summary>
            /// 特攻を降順にソート
            /// </summary>
            public void ExAtkDescendSort()
            {
                // pokelib = pokelib.OrderByDescending(x=> x.exatk);

                // foreach (var item in pokemonList.pokemons)
                // {
                    
                // }
            }

            /// <summary>
            /// すばやさを昇順にソート
            /// </summary>
            public void SpdAscendSort()
            {
                // pokemonList.pokemons =  pokemonList.pokemons.OrderBy(x=> x.spd);
                // foreach (var item in pokemonList.pokemons)
                // {
                    
                // }
            }



        }
    }
}