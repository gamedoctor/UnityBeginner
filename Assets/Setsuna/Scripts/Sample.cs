using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sample
{
    public class Sample : MonoBehaviour
    {
        [SerializeField] private Rigidbody target;

        public void Start()
        {
            // 課題
            // ソースコード・Rigidbody全て触るの禁止
            // 触ってよいのは準備されたPhysicMaterialのみ
            // Ball1, Floor, Floor_2, Floor_3, Floor_4, Wallを編集し、
            // 問.1～問.3全ての条件を満たす設定にせよ
            //
            // 応用課題
            // 問.1～問.3を満たした上でキーボードVを操作した場合、
            // AddForceを1回使って青いスポットライトにボールが止まるようにせよ
            // この課題のみ、QuestionSP内にAddForceを1度だけ追加しても良い
            
            PlayAllAction();
            StartCoroutine(Reload());

            void PlayAllAction()
            {
                StartCoroutine(Question1());
                StartCoroutine(Question2());
                StartCoroutine(Question3());
                StartCoroutine(QuestionSP());
            }

            // 問.1 黄色のスポットライトに止まるようにせよ (うまくいってなくてだめ)
            IEnumerator Question1()
            {
                yield return new WaitWhile(() => !target.IsSleeping());
                yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.Z));
                target.AddForce(-150, 0, 0);
            }

            // 問.2 緑色のスポットライトに止まるようにせよ
            IEnumerator Question2()
            {
                yield return new WaitWhile(() => !target.IsSleeping());
                yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.X));
                target.AddForce(-70, 600, 0);
            }
            
            // 問.3 紫色のスポットライトに止まるようにせよ
            IEnumerator Question3()
            {
                yield return new WaitWhile(() => !target.IsSleeping());
                yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.C));
                target.AddForce(-1350, 0, 0);
            }
            
            // 応用課題
            IEnumerator QuestionSP()
            {
                yield return new WaitWhile(() => !target.IsSleeping());
                yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.V));
                // ここにAddForceを記述する
            }

            IEnumerator Reload()
            {
                yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.F12));
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
