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
            // スターカップで以下のレースを開催する
            // レース1: マリオサーキット
            // レース2: ヨッシーバレー
            // レース3: おばけサーキット
            // レース4: レインボーロード

            var cup = new Cup {name = "スターカップ"};

            var course1 = new Course1 {name = "マリオサーキット"};
            var course2 = new Course2 {name = "ヨッシーバレー"};
            var course3 = new Course3 {name = "おばけサーキット"};
            var course4 = new Course4 {name = "レインボーロード"};

            cup.AddCourse(course1);
            cup.AddCourse(course2);
            cup.AddCourse(course3);
            cup.AddCourse(course4);

            var machine1 = new Bike("マリオ", 2, 2, 2, 2);
            var machine2 = new Bike("ルイージ", 2, 2, 2, 1);
            var machine3 = new Bike("ワリオ", 2, 2, 1, 3);
            var machine4 = new Cart("クッパ", 3, 1, 1, 3);
            var machine5 = new Cart("デイジー", 2, 3, 3, 1);
            var machine6 = new Bike("ロゼッタ様", 3, 3, 3, 2);
            var machine7 = new Cart("キノピオ", 3, 4, 3, 1);
            var machine8 = new Bike("ヨッシー", 3, 4, 3, 2);
            var machine9 = new Cart("キャサリン", 2, 2, 2, 3);
            var machine10 = new Cart("ドソキーユング", 1, 1, 1, 4);

            cup.AddMachine(machine1);
            cup.AddMachine(machine2);
            cup.AddMachine(machine3);
            cup.AddMachine(machine4);
            cup.AddMachine(machine5);
            cup.AddMachine(machine6);
            cup.AddMachine(machine7);
            cup.AddMachine(machine8);
            cup.AddMachine(machine9);
            cup.AddMachine(machine10);


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
            var result = cup.Execute();
            var step = 1;
            foreach (var machineResult in result.results.Take(3))
            {
                Debug.Log($"{step}位, {machineResult.machine.name} score:{machineResult.score}");
                step++;
            }
        }
    }

    public class Cup
    {
        public string name;

        public List<MachineBase> machines = new List<MachineBase>();
        public List<Course> courses = new List<Course>();

        public void AddMachine(MachineBase machine)
        {
            machines.Add(machine);
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public CupResult Execute()
        {
            var raceResults = courses
                .Select(x => x.GetCourseResult(machines.ToArray()))
                .Select(x => new RaceResult {results = x})
                .ToArray();

            var cupResult = new CupResult();
            cupResult.results = machines.Select(x => new CupMachineResult {machine = x}).ToArray();
            var scoreMap = new Dictionary<int, int> {{0, 10}, {1, 8}, {2, 7}, {3, 5}};
            foreach (var result in raceResults)
            {
                for (var i = 0; i < 4; i++)
                {
                    var r = result.results[i];
                    var target = cupResult.results.First(x => x.machine == r.machine);
                    target.score += scoreMap[i];
                }
            }

            cupResult.results = cupResult.results.OrderByDescending(x => x.score).ToArray();

            return cupResult;
        }
    }

    public class CupResult
    {
        public CupMachineResult[] results;
    }

    public class CupMachineResult
    {
        public MachineBase machine;
        public int score;
    }

    public class RaceResult
    {
        public CourseResult[] results;
    }

    public class Course1 : Course
    {
        public override int GetScore(MachineBase machine)
        {
            var score = machine.speed + machine.accelerator - machine.weight;
            switch (machine)
            {
                case Bike v:
                    score += 2;
                    break;
            }

            return score;
        }
    }

    public class Course2 : Course
    {
        public override int GetScore(MachineBase machine)
        {
            var score = machine.speed / 2 + machine.grip - machine.weight;
            switch (machine)
            {
                case Bike v:
                    score -= 1;
                    break;
            }

            return score;
        }
    }

    public class Course3 : Course
    {
        public override int GetScore(MachineBase machine)
        {
            var score = machine.speed * 2 + machine.grip * 2 - machine.weight;
            switch (machine)
            {
                case Cart v:
                    score += 1;
                    break;
                case Bike v:
                    score -= 1;
                    break;
            }

            return score;
        }
    }

    public class Course4 : Course
    {
        public override int GetScore(MachineBase machine)
        {
            var score = machine.speed + machine.grip * 2 + machine.accelerator * 2;
            switch (machine)
            {
                case Cart v:
                    score += 1;
                    break;
                case Bike v:
                    score -= 2;
                    break;
            }

            return score;
        }
    }


    public class Course
    {
        public virtual CourseResult[] GetCourseResult(MachineBase[] machines)
        {
            return machines
                .Select(x => new CourseResult {machine = x, score = GetScore(x)})
                .OrderByDescending(x => x.score)
                .ToArray();
        }

        public virtual int GetScore(MachineBase machine)
        {
            throw new NotImplementedException();
        }

        public string name;
    }

    public class CourseResult
    {
        public MachineBase machine;
        public int score;
    }

    public class Cart : MachineBase
    {
        public Cart(string name, int speed, int grip, int accelerator, int weight) : base(name, speed, grip,
            accelerator, weight)
        {
        }
    }

    public class Bike : MachineBase
    {
        public Bike(string name, int speed, int grip, int accelerator, int weight) : base(name, speed, grip,
            accelerator, weight)
        {
        }
    }

    public class MachineBase
    {
        public string name;
        public int speed;
        public int grip;
        public int accelerator;
        public int weight;

        public MachineBase(string name, int speed, int grip, int accelerator, int weight)
        {
            this.name = name;
            this.speed = speed;
            this.grip = grip;
            this.accelerator = accelerator;
            this.weight = weight;
        }
    }
}