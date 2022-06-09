using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        [SerializeField] private GameObject ball;
        [SerializeField] private Camera camera;
        [SerializeField] private GameObject FloorObj;
        public void Start()
        {
            IEnumerator cameraUpdate()
            {
                while (true)
                {
                    camera.gameObject.transform.position = new Vector3(
                        ball.transform.position.x , ball.transform.position.y ,
                        camera.gameObject.transform.position.z
                    );
                    yield return null;
                }
            }
            StartCoroutine(cameraUpdate());
            
            // 課題.1
            // "Ball"というオブジェクトをGoalというコライダーを通過させよ
            // 成功すると"OK!OK!OK!"と表示される
            IEnumerator MoveObj(GameObject obj, Vector3 tgtPos, float sec)
            {
                Vector3 basePos = obj.transform.position;
                float ckTime = 0;
                while (ckTime < sec)
                {
                    ckTime += Time.deltaTime * Time.timeScale;
                    obj.transform.position = Vector3.Lerp(basePos, tgtPos, ckTime / sec);
                    yield return null;
                }
            }
            IEnumerator RptateObj(GameObject obj, float tgtZ, float sec)
            {
                float baseZ = obj.transform.localRotation.z;
                float ckTime = 0;
                while (ckTime < sec)
                {
                    ckTime += Time.deltaTime * Time.timeScale;
                    obj.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Lerp(baseZ , tgtZ , ckTime / sec));
                    yield return null;
                }
            }
            StartCoroutine(MoveObj(FloorObj, new Vector3(-4.5f, 4, 0), 5));
            StartCoroutine(RptateObj(FloorObj, -8, 5));

            // 課題.2
            // 課題.1のゴール後にステージを作成せよ
            // ステージ2は坂道を作り、ゴール先の壁にぶつかって落下した先にゴール判定を作ること

            // 課題.3
            // 課題.2のゴール後にステージを作成せよ
            // 課題.2のゴール後にしばらく落下させ、特定のポイントに入ったら真横にボールを飛ばし、
            // 床の上にボールが設置されるようにせよ
        }
    }
}