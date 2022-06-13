using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        private void Start()
        {
            // 課題で使うオブジェクト
            target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            target.transform.localPosition = new Vector3();
            
            // 課題.1
            // targetを3秒かけてローカル座標の X:1, Y:1, Z:0  に移動させよ
            // 実装時は等速で移動するようにすること

            //StartCoroutine(Move());

            // 課題.2
            // targetを1秒のループ処理で係数1～1.5で10秒間実行する処理を実装せよ
            // 1秒までは拡大、2秒までは縮小の5ループが実行される
            
            //StartCoroutine(Move2());

            // 課題.3
            // targetを座標(x:0, y:0, z:0) を中心に距離3の位置で回転するようなロジックを実装せよ
            // またその先に課題.2で実装した拡縮するような実装も合わせて行うこと
            StartCoroutine(Satellite());

        }

        private IEnumerator Move()
        {
            var nowTime = 0f;
            var endTime = 3f;


            Vector3 startPosition = new Vector3(0,0,0);
            Vector3 targetPosition = new Vector3(1,1,0);
            // ウインドウを開く
            while (nowTime < endTime)
            {
                nowTime += Time.deltaTime;
                var aaaa = Mathf.Clamp01(nowTime/endTime);//拡大
                target.transform.localPosition = Vector3.Lerp(startPosition, targetPosition,aaaa);                  
                yield return null;    


            }
        }

        private IEnumerator Move2()
        {
            var nowTime = 0f;
            var endTime = 10f;
            float aaaa;
            var countTime = 0f;
            bool moveType = true;

            Vector3 startSize = target.transform.localScale;
            Vector3 targetSize = new Vector3(1.5f,1.5f,1.5f);

            // ウインドウを開く
            while (nowTime < endTime)
            {
                nowTime += Time.deltaTime;
                countTime += Time.deltaTime;

                if (countTime > 1.0f) 
                {
                    moveType = !moveType;
                    countTime = 0f;
                }
                aaaa = Mathf.Clamp01(countTime/1.0f);
                if (moveType)
                {
                    target.transform.localScale = Vector3.Lerp(startSize, targetSize, aaaa);
                }
                else
                {
                    target.transform.localScale = Vector3.Lerp(targetSize, startSize, aaaa);
                }
                
                yield return null;
                
            }
        }
    
        private IEnumerator Satellite()
        {
            float aaaa;
            var countTime = 0f;
            bool moveType = true;

            Vector3 startSize = target.transform.localScale;
            Vector3 targetSize = new Vector3(1.5f,1.5f,1.5f);


            //ターゲットを中心点から3の座標に代入し続ける
            target.transform.localPosition = new Vector3(0,3,0);
            while (true)
            {
                target.transform.RotateAround(new Vector3() ,Vector3.forward , 20*Time.deltaTime);
                countTime += Time.deltaTime;

                if (countTime > 1.0f) 
                {
                    moveType = !moveType;
                    countTime = 0f;
                }
                aaaa = Mathf.Clamp01(countTime/1.0f);
                if (moveType)
                {
                    target.transform.localScale = Vector3.Lerp(startSize, targetSize, aaaa);
                }
                else
                {
                    target.transform.localScale = Vector3.Lerp(targetSize, startSize, aaaa);
                }
                yield return null;
            }
            //中心に
            



            
        }
    
    
    
    }
}