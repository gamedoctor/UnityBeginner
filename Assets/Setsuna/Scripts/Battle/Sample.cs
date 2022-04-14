using System.Collections.Generic;
using UnityEngine;

namespace Setsuna
{
    public class Sample : MonoBehaviour
    {
        public void Start()
        {
            // カート : カートを定義する
            Cart mario = new Cart("マリオ", 3, 3, 2, 3);
            Cart luigi = new Cart("ルイージ", 3, 3, 3, 2);
            Cart yoshi = new Cart("ヨッシー", 4, 4, 2, 1);
            Cart peach = new Cart("ピーチ", 4, 3, 3, 1);
            Cart donkey = new Cart("ドソキーユング", 5, 1, 1, 5);
            Cart kuppa = new Cart("クッパ", 5, 1, 2, 4);
            Cart kinopio = new Cart("キノピオ", 5, 5, 5, 1);

            // // マリオと表示
            // Debug.Log(mario.GetName());
            //
            // // 以下２つの結果は何がはいるか
            // Debug.Log(yoshi.GetTotalStatus());
            // Debug.Log(donkey.GetTotalStatus());

            // カップ : カップを定義する
            Cup cup = new Cup("キノコカップ");
            cup.Entry(mario);
            cup.Entry(luigi);
            cup.Entry(yoshi);
            cup.Entry(peach);
            cup.Entry(donkey);
            cup.Entry(kuppa);
            cup.Entry(kinopio);

            // 繰り返し文
            // while, for, foreach
            // while=条件を満たしている場合、繰り返す
            // while (条件式(bool)) true=真, false=偽
            // while (true)
            // {
            //     // 無限ループ
            // }
            //
            // while (false)
            // {
            //     // 一回も実行されない
            // }

            // for (初動; 条件式; ステップ実行)
            // {
            //     
            // }
            // ++ = インクリメント、+1する
            // < = これは未満を意味する
            // <= = これは以下を意味する
            // for (int i = 0; i < 10; i = i + 1)
            // {
            // }
            //
            // // ちなみにこれは無限ループ
            // for (; true;)
            // {
            //     
            // }

            // foreach(型 変数名 in 配列型のリスト)
            // foreach (Cart cart in cup.GetEntries())
            // {
            //     Debug.Log(cart.GetName());
            // }
            //
            // List<Cart> carts = cup.GetEntries();
            // for (int i = 0; i < carts.Count; i++)
            // {
            //     Debug.Log(carts[i].GetName());
            // }

            // 課題:
            // フラワーカップを定義しなさい
            // 既に定義済みのマリオ、ルイージ、ピーチ、クッパは参加
            // 今は定義のないヘイホー、デイジーを追加し
            // foreachを使って
            // ピーチ、デイジー、ヘイホー、マリオ、ルイージ、クッパ
            // の順番にログを表示するように実装しなさい

            // ここにコードを書いていく
        }
        public void Start();

            //カートの定義
            Cart heiho = new Cart("ヘイホー", 2, 3, 4, 1);
            Cart daisy = new Cart("デイジー", 3, 3, 3, 2);

            //カップの定義
            Cup cup = new Cup("フラワーカップ");
            cup.Entry(peach);
            cup.entry(daisy);
            cup.Entry(heiho);
            cup.Entry(mario);
            cup.Entry(luigi);
            cup.Entry(kuppa);

            //ログを表示する
            foreach (Cart cart in cup.GetEntries())
            {
                Debug.Log(cart.GetName());
            }
            
            
    }

    public class Cart
    {
        // 名前
        public string name;

        // スピード
        public int speed;

        // グリップ
        public int grip;

        // 加速
        public int accelerator;

        // 重量
        public int weight;

        // コンストラクタの書き方
        // 修飾子 クラス名(引数)
        public Cart(string name, int speed, int grip, int accelerator, int weight)
        {
            // thisは自分自身、this=クラス
            this.name = name;
            this.speed = speed;
            this.grip = grip;
            this.accelerator = accelerator;
            this.weight = weight;
        }

        // 関数の書き方
        // 修飾子 型 名前(引数)
        // public = 修飾子
        //   public = どこからでもアクセスできる
        //   protected = 継承先までアクセスOK
        //   private = 自分自身以外のアクセス禁止
        // 
        // void = 型　※voidはないという意味、戻り値がない
        // 関数 = 関数の名称
        // () = 引数、()だけだと引数なし
        // {  }
        public void 関数()
        {
            return;
        }

        // 修飾子 型 関数名(引数)
        // この場合、戻り値は「変数 name」になる
        public string GetName()
        {
            // string = 文字列を意味する
            // return this.name と同等
            return name;
        }

        public int GetTotalStatus()
        {
            return speed + grip + accelerator + weight;
        }
    }

    public class Cup
    {
        public string name;

        // List型
        // List型を説明する前に「配列」の説明
        // 配列とは
        // 複数の数値をまとめる変数
        // int value1, value2, value3…
        // int[] values = new int[3];
        //   values[0], values[1], values[2]は取得できる
        //   values[3]ってしようとするとエラーになる
        // List型とは
        //   List型は配列をパフォーマンスを犠牲にする代わりに使いやすくしたもの
        //   array型 = 決まられた枠で動かすため、パフォーマンスが良い(速さなど)
        //   List型 = arrayより重いかったりする　※パフォーマンスは全般を指すので速さだけではない
        // ☆具体的に何が使いやすいか
        // 配列は「後で長さを伸ばすのが難しい」
        // List型は「簡単に長さをかえることができる」
        // 長さをかえるというのは、 new int[3]; だと長さが3。
        // new int[4]にするのは地味に大変
        // この苦労をなくすことができるのがList型
        // 型<ジェネリック型> 変数名;と記述する
        // ジェネリック型は実際にリストにしたい変数の型を書く
        public List<Cart> entries;

        public List<Cart> GetEntries()
        {
            return entries;
        }

        public void Entry(Cart cart)
        {
            entries.Add(cart);

            // これをもし配列 Cart[] はこうなる
            // Cart[] carts = new Cart[0];
            // Cart[] cache = new Cart[carts.Length];
            // for (int i = 0; i < carts.Length; i++)
            // {
            //     cache[i] = carts[i];
            // }
            //
            // carts = new Cart[carts.Length + 1];
            // for (int i = 0; i < carts.Length; i++)
            // {
            //     carts[i] = i < cache.Length ? cache[i] : cart;
            // }
        }

        public Cup(string name)
        {
            this.name = name;
            entries = new List<Cart>();
        }
    }

    public class Race
    {
    }
}