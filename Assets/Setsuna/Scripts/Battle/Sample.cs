using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Setsuna
{
    public class Sample : MonoBehaviour
    {

        public enum MachineType
        {
            CART,
            BIKE
        }

        public enum RaceNumber
        {
            MARIOCIRCUIT,
            YOSHIVALLEY,
            OBAKEOCIRCUIT,
            RAINBOWROAD


        }

        //カップ
        Cup starcup = new Cup("スターカップ");

        //レース
        Race MarioCircuit = new Race("マリオサーキット");
        Race YoshiValley = new Race("ヨッシーバレー");
        Race ObakeCircuit = new Race("おばけサーキット");
        Race RainbowRoad = new Race("レインボーロード");

        //参加者
        Character mario =      new Character("マリオ", 2, 2, 2, 2,(int)MachineType.BIKE);
        Character luigi =      new Character("ルイージ", 2, 2, 2, 1,(int)MachineType.BIKE);
        Character wario =      new Character("ワリオ", 2, 2, 1, 3,(int)MachineType.BIKE);
        Character koopa =      new Character("クッパ", 3, 1, 1, 3,(int)MachineType.CART);
        Character daizy =      new Character("デイジー", 2, 3, 3, 1,(int)MachineType.CART);
        Character Ms_Rosetta = new Character("ロゼッタ様", 3, 3, 3, 2,(int)MachineType.BIKE);
        Character kinopio =    new Character("キノピオ", 3, 4, 3, 1,(int)MachineType.CART);
        Character yoshi =      new Character("ヨッシー", 3, 4, 3, 2,(int)MachineType.BIKE);
        Character kyasarin =   new Character("キャサリン", 2, 2, 2, 3,(int)MachineType.CART);
        Character donky =      new Character("ドソキーユング", 1, 1, 1, 4,(int)MachineType.CART);

        

        public void Start()
        {
            // 課題:
            // スターカップで以下のレースを開催する
            // レース1: マリオサーキット
            // レース2: ヨッシーバレー
            // レース3: おばけサーキット
            // レース4: レインボーロード
            
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
             
            // レースに出る際にカート・バイクでそれぞれ乗り物が変えられるとする
            // 乗り物はそれぞれベースとしてマシンというクラスを作り、継承で作るようにする
            // カップ・レースクラスもそれぞれ用意すること
            // マリオ・ルイージ・ワリオ・ロゼッタ様・ヨッシーはバイクとする
            
            // それぞれのクラスには名前と性能の情報がある
            // デバッグログとしては以下の情報を表示させよ

            
            // ソートについてはLinq機能のOrderByを使うこと。降順のできるので使い方は調べること
            

            
            starcup.RaceAdd(MarioCircuit);            
            starcup.RaceAdd(YoshiValley);
            starcup.RaceAdd(ObakeCircuit);
            starcup.RaceAdd(RainbowRoad);

            Debug.Log(mario.name);
            starcup.Entry(mario);
            starcup.Entry(luigi);
            starcup.Entry(wario);
            starcup.Entry(koopa);
            starcup.Entry(daizy);
            starcup.Entry(Ms_Rosetta);
            starcup.Entry(kinopio);
            starcup.Entry(yoshi);
            starcup.Entry(kyasarin);
            starcup.Entry(donky);


            starcup.run();
        }




        public class Character
        {
            public Character(string name, int speed, int grip, int accelerator, int weight ,int MachineType)
            {
                cart.Init(speed,grip,accelerator,weight);
                bike.init(speed,grip,accelerator,weight);
                machineSelect(MachineType);
                this.name = name;
                totalscore = 0;
            }
            public Cart cart = new Cart();
            public Bike bike = new Bike();
            public string name;
            public int useMachineType;
            public int totalscore;
            public int racescore;

            void machineSelect(int MachineType)
            {
                useMachineType = MachineType;
            }
        }

        public class Machine
        {
            public int speed;
            public int grip;
            public int accelerator;
            public int weight;

        }

        public class Cart : Machine
        {
            public void Init(int speed, int grip, int accelerator, int weight)
            {                       
                this.speed = speed;
                this.grip = grip;
                this.accelerator = accelerator;
                this.weight = weight;
            }
          
        }

        public class Bike : Machine
        {
            public void init(int grip, int speed, int accelerator, int weight)
            {                              
                this.speed = speed;
                this.grip = grip;
                this.accelerator = accelerator;
                this.weight = weight;

            }    
            
        }


        public class Cup
        {
            public string name;
            public List<Character> entries = new List<Character>();
            public List<Race> races = new List<Race>();
            public RaceNumber racenum = new RaceNumber();
            Result result = new Result();

            public Cup(string name)
            {
                this.name = name;
                entries = new List<Character>();
                racenum = RaceNumber.MARIOCIRCUIT;
            }

            /// <summary>
            /// 参加者リスト取得
            /// </summary>
            /// <returns></returns>
            public List<Character> Getentries()
            {
                return entries;
            }
            /// <summary>
            /// レースリスト取得
            /// </summary>
            /// <returns></returns>
            public List<Race> Getraces()
            {
                return races;
            }

            /// <summary>
            /// レース参加者を追加
            /// </summary>
            /// <param name="character">追加する参加キャラクター</param>
            public void Entry(Character character)
            {
                entries.Add(character);
            }

            /// <summary>
            /// レースをリストに追加
            /// </summary>
            /// <param name="race">追加するレース</param>
            public void RaceAdd(Race race)
            {
                races.Add(race);
            }

            /// <summary>
            /// キャラクター達にレースをさせる
            /// </summary>
            public void run()
            {
                int count = 0;
                while (races.Count > count)
                {
                    RaceRankinngCalc();
                    result.RaceResult(entries);
                    racenum += 1;
                }

                result.TotalScoreSort(entries);
                
            }

            /// <summary>
            /// レースの順位を計算
            /// </summary>
            public void RaceRankinngCalc()
            {
                switch (racenum)
                {
                    case RaceNumber.MARIOCIRCUIT:                    
                    // マリオサーキット => 速度と重さと加速を引き算した数値が高い順番
                    //   バイクはこの結果に対して+2とする
                    Debug.Log(races[(int)racenum].name);
                    for (int i = 0; i < entries.Count; i++)
                    {
                        if (entries[i].useMachineType == (int)MachineType.CART)
                        {
                            entries[i].racescore = 0;
                            entries[i].racescore -= entries[i].cart.speed - entries[i].cart.weight -  entries[i].cart.accelerator;
  
                        }
                        else
                        {
                            entries[i].racescore = 0;
                            entries[i].racescore -= entries[i].bike.speed - entries[i].bike.weight - entries[i].bike.accelerator;                           
                            entries[i].racescore += 2;
                        }
                    }
                    

                    break;

                    case RaceNumber.YOSHIVALLEY:
                    // ヨッシーバレー => 速度÷2とグリップの合算に重さを引き算した数値で高い順番
                    //   カートはこの結果に対して+1、バイクは-1とする
                    Debug.Log(races[(int)racenum].name);
                    for (int i = 0; i < entries.Count; i++)
                    {
                        if (entries[i].useMachineType == (int)MachineType.CART)
                        {
                            entries[i].racescore = 0;
                            entries[i].racescore = (entries[i].cart.speed / 2) + entries[i].cart.grip - entries[i].cart.weight;
                            entries[i].racescore += 1;

                        }
                        else
                        {
                            entries[i].racescore = 0;
                            entries[i].racescore = (entries[i].bike.speed / 2) + entries[i].bike.grip- entries[i].bike.weight;
                            entries[i].racescore -= 1;
                        }
                    }


                    break;

                    case RaceNumber.OBAKEOCIRCUIT:
                    // おばけサーキット=> 速度×2とグリップ×2の合算に重さを引き算した数値で高い順番
                    //   バイクはこの結果に対して-1とする
                    Debug.Log(races[(int)racenum].name);
                    for (int i = 0; i < entries.Count; i++)
                    {
                        if (entries[i].useMachineType == (int)MachineType.CART)
                        {
                            entries[i].racescore = 0;
                            entries[i].racescore = (entries[i].cart.speed * 2 + entries[i].cart.grip * 2) - entries[i].cart.weight;                           
                        }
                        else
                        {
                            entries[i].racescore = 0;
                            entries[i].racescore = (entries[i].bike.speed * 2 + entries[i].bike.grip * 2) - entries[i].bike.weight;
                            entries[i].racescore -= 1;
                        }
                    }


                    break;

                    case RaceNumber.RAINBOWROAD:
                    // レインボーバレー=> 速度とグリップ×2と加速×2の合算で高い順番
                    //   バイクはこの結果に対して-2、カートは+1とする
                    Debug.Log(races[(int)racenum].name);
                    for (int i = 0; i < entries.Count; i++)
                    {
                        if (entries[i].useMachineType == (int)MachineType.CART)
                        {
                            entries[i].racescore = 0;
                            entries[i].racescore = entries[i].cart.speed + entries[i].cart.grip * 2 + entries[i].cart.accelerator * 2; 
                            entries[i].racescore += 1;                          
                        }
                        else
                        {
                            entries[i].racescore = 0;
                            entries[i].racescore = entries[i].bike.speed + entries[i].bike.grip * 2 + entries[i].bike.accelerator * 2;
                            entries[i].racescore -= 2;
                        }
                    }


                    break;
                    

                    
                }
            }



        }

        public class Race
        {
            public Race(string name)
            {
                this.name = name;
            }
            public string name;
        }

        public class Result
        {

            // 1位10点、2位8点、3位7点、4位5点としてカップの1位～3位を表示させよ
            // 各レースの表示と各レースの結果で1～4位の結果の表示をする
 

            /// <summary>
            /// 最終スコアを降順に並べ直す。
            /// </summary>
            public void TotalScoreSort(List<Character> entries)
            {
                var totalscore = entries.OrderByDescending(X => X.totalscore);
                int num = 0;
                //
                foreach (Character character in totalscore)
                {
                    num++;
                    Debug.Log("第" + num + "位" + character.name + " " + character.totalscore);
                    if (num >= 3)break;
                }
            }

            public void RaceResult(List<Character> entries)
            {
                var racescore = entries.OrderByDescending(X => X.racescore);
                int num = 0;
                
                entries[0].totalscore += 10;
                entries[1].totalscore += 8;
                entries[2].totalscore += 7;
                entries[3].totalscore += 5;

                
                foreach (Character character in racescore)
                {
                    num++;
                    Debug.Log("第" + num + "位" + character.name + " " + character.racescore);
                    if (num >= 4)break;
                }
            }
        }
    }

}