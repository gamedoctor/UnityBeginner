using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        public void Start()
        {
            // 丸の生成
            var instance = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            // ライト
            var light = new GameObject().AddComponent<Light>();
            light.transform.rotation = Quaternion.Euler(90, 0, 0);
            light.transform.position = new Vector3(0, 5, 0);
            light.type = LightType.Directional;
            
            // 課題.1
            // 球の色を様々なColorに変更する
            // 変更時は線形補間で切り替えるようにする
            // 模範解答:
            // https://drive.google.com/file/d/1oe1VRkQRGyNqLnVqv1AslrQAKepIsmtJ/view?usp=sharing

            // 課題.2
            // 球を3つ用意し、それぞれ並べる
            // その後、白→赤...、白→青...、白→緑...で色が交互に変わるようにスクリプトを組む
            // この時、色の切り替わりは全て同時である必要がある
            // ひとつの関数に全てまとめて記載するのはNG
        }
    }
}