using System.Collections.Generic;
using UnityEngine;

namespace Setsuna
{
    public class Sample : MonoBehaviour
    {
        public void Start()
        {
            // 課題:
            // スターカップで以下のレースを開催する
            // レース1: マリオサーキット
            // レース2: ヨッシーバレー
            // レース3: おばけサーキット
            // レース4: レインボーロード
            //
            // レースには以下のキャラクターが参加する、パラメータは左から「速度/グリップ/加速/重さ」
            // マリオ 2/2/2/2
            // ルイージ 2/2/2/1
            // ワリオ 2/2/1/3
            // クッパ 3/1/1/3
            // デイジー 2/3/3/1
            // ロゼッタ様 3/3/3/2
            // キノピオ 3/4/3/1
            // ヨッシー 3/4/3/2
            // キャサリン 2/2/2/3
            // ドソキーユング 1/1/1/4
            // 
            // レースに出る際にカート・バイクでそれぞれ乗り物が変えられるとする
            // 乗り物はそれぞれベースとしてマシンというクラスを作り、継承で作るようにする
            // カップ・レースクラスもそれぞれ用意すること
            // マリオ・ルイージ・ワリオ・ロゼッタ様・ヨッシーはバイクとする
            //
            // それぞれのクラスには名前と性能の情報がある
            // デバッグログとしては以下の情報を表示させよ
            //
            // 各レースの表示と各レースの結果で1～4位の結果の表示をする
            // 順位の決定はマシンの性能で決まる
            // マリオサーキット => 速度と重さと加速を引き算した数値が高い順番
            //   バイクはこの結果に対して+2とする
            // ヨッシーバレー => 速度÷2とグリップの合算に重さを引き算した数値で高い順番
            //   カートはこの結果に対して+1、バイクは-1とする
            // おばけサーキット=> 速度×2とグリップ×2の合算に重さを引き算した数値で高い順番
            //   バイクはこの結果に対して-1とする
            // レインボーバレー=> 速度とグリップ×2と加速×2の合算で高い順番
            //   バイクはこの結果に対して-2、カートは+1とする
            // で表示するようにすること
            // つまり各カートにはその性能がある
            // 1位10点、2位8点、3位7点、4位5点としてカップの1位～3位を表示させよ
            //
            // ソートについてはLinq機能のOrderByを使うこと。降順のできるので使い方は調べること



            //キャラクターの定義
            Character mario = new Character("マリオ", 2, 2, 2, 2);
            Character luigi = new Character("ルイージ", 2, 2, 2, 1);
            Character wario = new Character("ワリオ", 2, 2, 1, 3);
            Character koopa = new Character("クッパ", 3, 1, 1, 3);
            Character daisy = new Character("デイジー", 2, 3, 3, 1);
            Character rosetta = new Character("ロゼッタ", 3, 3, 3, 2);
            Character kinopio = new Character("キノピオ", 3, 4, 3, 1);
            Character yoshi = new Character("ヨッシー", 3, 4, 3, 2);
            Character catherine = new Character("キャサリン", 2, 2, 2, 3);
            Character donkey = new Character("ドソキーユング", 1, 1, 1, 4);


            //カップの定義
            Cup Starcup = new Cup("スターカップ");
            Starcup.entry(mario);
            Starcup.entry(luigi);
            Starcup.entry(wario);
            Starcup.entry(koopa);
            Starcup.entry(daisy);
            Starcup.entry(rosetta);
            Starcup.entry(kinopio);
            Starcup.entry(yoshi);
            Starcup.entry(catherine);
            Starcup.entry(donkey);


        }

        //キャラクターのクラスを作る
        public class Character

        
        //カートのクラスを作る
        public class Cart : machine
        {

        }

        //バイクのクラスを作る
        public class Bike : machine
        {

        }

        //マシンのクラスを作る
        public class machine
        {
            /// <summary>
            /// マシンの名前
            /// </summary>
            public string name;

            public int speed;

            public int grip;

            public int accelerator;

            public int weight;
        }

        //カップのクラスを作る
        public class Cup
        {
            public int firstrace;

            public int secondrace;

            public int thirdrace;

            public int lastrace;
        }


        //レースのカップを作る
        public class Starcup
        {
            firstrace = ("マリオサーキット")

            secondrace = ("ヨッシーバレー")

            thirdrace = ("おばけサーキット")

            lastrace = ("レインボーロード")
        }

        public class result
        {
        
        }


}