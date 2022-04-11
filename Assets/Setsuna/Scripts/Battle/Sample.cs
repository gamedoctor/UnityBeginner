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
            
            // マリオと表示
            Debug.Log(mario.GetName());
            
            // 以下２つの結果は何がはいるか
            Debug.Log(yoshi.GetTotalStatus());
            Debug.Log(donkey.GetTotalStatus());

            // カップ : カップを定義する
            Cup cup = new Cup("きのこカップ");
            cup.Entry(mario);
            cup.Entry(luigi);
            cup.Entry(yoshi);
            cup.Entry(peach);
            cup.Entry(donkey);
            cup.Entry(kuppa);
            cup.Entry(kinopio);
            
            // レース : レースを定義する
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

        public List<Cart> entry;

        public void Entry(Cart cart)
        {
            entry.Add(cart);
        }

        public Cup(string name)
        {
            this.name = name;
            entry = new List<Cart>();
        }
    }

    public class Race
    {
        
    }
}