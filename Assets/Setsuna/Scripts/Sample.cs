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
            // おさらい
            
            // int型 整数を扱う
            int value1 = 1;
            int value2 = int.MaxValue; // これで最大値をとれる
            
            // float型 小数点・単精度を扱う
            // 単精度とは、小数点が取りうる値は現実と違い、特定の桁数までの値のことを意味する、詳細は割愛。
            float fValue1 = 0.1f; // 文末にfをつける
            float fValue2 = 3; // 整数で代入する場合のみ省略可能
            // 単精度をわかりやすくした話
            float fValue3 = 1 / 3; // この時、割り算すると0.33333…という結果になる。
            float fValue4 = fValue3 * 3; 
            // fValue3は1を3で割った値なので再度かけると1になるはず
            // しかし、実際はそうはならず、特定の桁数までの計算になるので桁落ちが発生し、0.9999…となる
            
            // 演算(int, float)
            int result1 = 1 + 1; // 足し算
            int result2 = 1 - 1; // 引き算
            int result3 = 1 * 2; // 掛け算
            int result4 = 9 * 3; // 割り算
            int result5 = 9 % 5; // 割り算、余りを求める
            
            // string型 文字列
            string sValue1 = "文字列";
            string sValue2 = value1.ToString(); // このように変数にToStringの関数を実行すると文字列に変換できる
            
            // 比較演算 数値の比較・文字列の比較・値の比較が可能
            bool bValue1 = value1 == 1; // 完全一致、true or false。この結果を真偽値という。
            bool bValue2 = value1 > 1; // ～を超える場合
            bool bValue3 = value1 >= 1; // ～以上
            bool bValue4 = value1 < 1; // ～未満
            bool bValue5 = value1 <= 1; // ～以下
            bool bValue6 = value1 != 1; // 一致しない場合
            bool bValue7 = !bValue1; // 真偽値の反転、bool型に対して実行可能
            
            // 課題.1
            // for文を使って数学の階乗「10!」を求めよ
            
            // 課題.2
            // データが23件あり、1ページあたり5件表示するものとする。
            // その場合、8件目のデータ、13件目のデータ、21件目のデータそれぞれが何件目かを
            // 確認する関数を作成せよ
            
            // 課題.3
            // for文で100ループ実行し、
            // 3の倍数の時は赤文字
            // 5の倍数はスキップ
            // 6の倍数の時は青文字
            // 9の倍数の時は黄文字
            // それ以外は白文字にする処理を実装せよ
            // Debug.Logは1回のみで、1つの文字列でログ表示すること
            // 改行を表したい場合は「\n」をそれぞれの行の末尾に書けば可能
            // 優先度は上から順番であり、15は5の倍数だが3の倍数の処理が優先される。
        }
    }
}