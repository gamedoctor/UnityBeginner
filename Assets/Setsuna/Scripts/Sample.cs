using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        private GameObject target;

        private void Start()
        {
            // 課題で使うオブジェクト
            target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            transform.localPosition = new Vector3();
            
            // 課題.1
            // targetを3秒かけてローカル座標の X:1, Y:1, Z:0  に移動させよ
            // 実装時は等速で移動するようにすること

            // 課題.2
            // targetを1秒のループ処理で係数1～1.5で10秒間実行する処理を実装せよ
            // 1秒までは拡大、2秒までは縮小の5ループが実行される
            
            // 課題.3
            // targetを座標(x:0, y:0, z:0) を中心に距離3の位置で回転するようなロジックを実装せよ
            // またその先に課題.2で実装した拡縮するような実装も合わせて行うこと
        }
    }
}