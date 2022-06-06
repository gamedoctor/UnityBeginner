using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class study3 : MonoBehaviour
{
    public void Start()
    {
        // 丸の生成
        var instance0 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        List<GameObject> instances = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
            var instance = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            instance.transform.position = new Vector3(i - 1, 2, 0);
            instances.Add(instance);
        }

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
        Material m_material = instance0.GetComponent<Renderer>().material;
        IEnumerator _SetColCng(Material mat)
        {
            while (true)
            {
                yield return _colCng(mat,Color.white, 1);
                yield return _colCng(mat,Color.blue, 1);
                yield return _colCng(mat,Color.green, 1);
                yield return _colCng(mat,Color.magenta, 1);
                yield return _colCng(mat,Color.yellow, 1);
                yield return _colCng(mat,Color.cyan, 1);
            }
        }
        IEnumerator _colCng(Material mat , Color color , float sec)
        {
            float ckTime = 0;
            Color baseCol = mat.color;
            while (ckTime < sec)
            {
                ckTime += Time.deltaTime * Time.timeScale;
                mat.color = Color.Lerp(baseCol, color, Mathf.Clamp01(ckTime / sec));
                yield return null;
            }
        }
        StartCoroutine(_SetColCng(m_material));

        // 課題.2
        // 球を3つ用意し、それぞれ並べる
        // その後、白→赤...、白→青...、白→緑...で色が交互に変わるようにスクリプトを組む
        // この時、色の切り替わりは全て同時である必要がある
        // ひとつの関数に全てまとめて記載するのはNG
        IEnumerator _ClmpCol(Material mat, Color one1, Color col2)
        {
            while (true)
            {
                yield return _colCng(mat,one1, 1);
                yield return _colCng(mat,col2, 1);
            }
        }
        List<Material> ckMats = instances.Select(x => x.GetComponent<Renderer>().material).ToList();
        StartCoroutine(_ClmpCol(ckMats[0], Color.white, Color.red));
        StartCoroutine(_ClmpCol(ckMats[1], Color.white, Color.green));
        StartCoroutine(_ClmpCol(ckMats[2], Color.white, Color.blue));
    }
}
