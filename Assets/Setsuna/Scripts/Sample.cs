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
            // ------------------------------------------------------------------------------
            // 問.1
            // クラス名Itemを作成せよ
            // 変数はint型のidとstring型のnameとint型のvalueを持つ
            // コンストラクタを利用して値は代入すること
            // ------------------------------------------------------------------------------

            // ------------------------------------------------------------------------------
            // 問.2
            // Itemクラスの配列を作成し、以下のデータを配列の要素として準備をせよ
            // ID: 1, 名前: ソード, 値: 5
            // ID: 2, 名前: ロッド, 値: 2
            // ID: 3, 名前: カード, 値: 3
            // ヒント: Addを使わない実装も可能、インスタンス生成する時にまとめることができる
            // ------------------------------------------------------------------------------

            var Item1 = new Item(1, "ソード", 5);
            var Item2 = new Item(2, "ロッド", 2);
            var Item3 = new Item(3, "カード", 3);

            // ------------------------------------------------------------------------------
            // 問.3
            // Itemクラスの配列からから名前に「ー」が含まれる配列を取得し
            // valueを昇順にソートしてログに表示させよ
            // ログに表示する内容は「ID: 1, 名前: ソード, 値: 5」といった形式にすること
            // ヒント: 文字列内に特定の文字が含まれているかをチェックする処理が存在している
            // ------------------------------------------------------------------------------
            
            Item[] items = new Item[3];

            items[0] = Item1;
            items[1] = Item2;
            items[2] = Item3;

            items = items.OrderByDescending(x => x.value).ToArray();
            //foreach (var Item in items)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    var Item = items[i];
                    string Logtext = Item.name;
                    if (Logtext.Contains("ー"))
                    {
                        Debug.Log($"ID:{Item.ID}, 名前{Item.name}, 値:{Item.value}");
                    }
                }
            }

            //インデックス = []←コレ
            //配列のインデックスには個数、配列単体のインデックスは0から数えて入力する

            //配列をfor文で全部回すのであれば、【int i = 0】で、条件が【i < "配列".Length】未満で回すこと
            //Length = 長さ

            Debug.Log("---------------------------------------------------------------");

            // ------------------------------------------------------------------------------
            // 問.4
            // 問.2で作成したデータそれぞれに名前の末尾に「改」をつけて値を1.5倍にした
            // データを作成し配列に追加せよ、掛け算した際の小数点は切り捨てとする
            // ヒント: foreachを使う場合、配列データの長さが変わるとエラーになる
            // ヒント: クラスを複製するという機能は原則存在しないため、自前で実装する必要がある
            // ------------------------------------------------------------------------------

            //Item Itemkai1 = Item1.Clone();
            //Item Itemkai2 = Item2.Clone();
            //Item Itemkai3 = Item3.Clone();

            Item[] itemkais = new Item[3];

            itemkais[0] = Item1.Clone();
            itemkais[1] = Item2.Clone();
            itemkais[2] = Item3.Clone();

            //関数を呼び出す時は()をつける
            //関数は引数がゼロでも()が必要

            foreach (var Item in itemkais)
            {
                Item.name += "改";
                float num = Item.value;
                num *= 1.5f;
                Item.value = (int)num;
            }

            List<Item> Itemlist = items.ToList();
            Itemlist.Add(itemkais[0]);
            Itemlist.Add(itemkais[1]);
            Itemlist.Add(itemkais[2]);

            itemkais = Itemlist.ToArray();

            for (int i = 0; i < itemkais.Length; i++)
            {
                var Item = itemkais[i];
                string Logtext = Item.name;
                //if (Logtext.Contains("ー"))
                {
                    Debug.Log($"ID:{Item.ID}, 名前{Item.name}, 値:{Item.value}");
                }
            }

            //掛け算は"*"(ケツの穴って覚える)
            //int型は整数しか扱えない
            //小数点を扱う時はfloat型を行う
            //小数点を扱う時は末尾にfをつける
        }

        // ここにクラスを書く
        public class Item
        {
            public int ID;
            public string name;
            public int value;

            public Item(int ID, string name, int value)
            {
                this.ID = ID;
                this.name = name;
                this.value = value;
            }

            public Item Clone()
            {
                Item cloneItem = new Item(ID, name, value);
                return cloneItem;
            }
            //複製する時はnewを使って代入する
        }
    }
}