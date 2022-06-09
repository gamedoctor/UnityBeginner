using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        public static bool goal;
        public void Start()
        {
            // 課題.1
            // "Ball"というオブジェクトをGoalというコライダーを通過させよ
            // 成功すると"OK!OK!OK!"と表示される
            StartCoroutine(TestCoroutine());
            IEnumerator TestCoroutine()
            {
                var current = 0f;
                var time = 3;
                while (current < time)
                {
                    current += Time.deltaTime;
                    rigidbody.AddForce(new Vector3(1, 0));
                    yield return null;
                }
                yield return new WaitForSeconds(1);
            }

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