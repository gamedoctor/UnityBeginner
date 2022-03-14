using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScene : MonoBehaviour
{
    public Button startButton;
    public Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        titleText.text = "竜がガバ";

        startButton.onClick.AddListener(() =>
        {
            titleText.text = "竜がガバガバ";
        });
        
        // startButton.onClick.AddListener(() =>
        // {
        //     titleText.text = "竜がガバガバ";
        // });
        // 上記の処理は無名関数という。
        // 処理の働きとしては
        // 
        // startButton.onClick.AddListener(OnStart);
        // void OnStart()
        // {
        //     titleText.text = "竜がガバガバ";
        // }
        // と同じ処理
    }

    // Update is called once per frame
    void Update()
    {
    }
}