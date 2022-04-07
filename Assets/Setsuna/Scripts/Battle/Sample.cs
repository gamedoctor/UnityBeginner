using UnityEngine;

namespace Setsuna
{
    public class Sample : MonoBehaviour
    {
        public void Start()
        {
            // 親オブジェクトを生成する
            親 親 = new 親();
            // 「私は親」と表示される
            親.名乗り();
            // 「私は山口県出身です」と表示される
            親.住まい();

            親 ダディ = new 親();
            // 「私は親」と表示される
            ダディ.名乗り();
            // 「私は山口県出身です」と表示される
            ダディ.住まい();
            // 何が表示される？
            ダディ.出身国();
            ダディ.名前 = "ギャレン";

            子 子 = new 子();
            // 問題:「？」と表示される、？は何
            子.名乗り();
            // 問題:「？」と表示される、？は何
            子.住まい();
            // 何が表示される？
            子.出身国();
            子.名前 = "キッズ";

        }

        public void Update()
        {
            // フレーム毎に実行する
        }
    }

    public class 親
    {
        public string 名前;
        
        private string country = "アメリカ";

        public virtual void 名乗り()
        {
            Debug.Log("私は親");
        }

        public virtual void 住まい()
        {
            Debug.Log("私は山口県出身です");
        }

        public virtual void 出身国()
        {
            Debug.Log(country);
        }
    }

    public class 子 : 親
    {
        private string country = "日本";

        public string 名前;

        public void 名前を名乗る()
        {
            // 子の名前が表示
            Debug.Log(名前);
            // 親の名前が表示
            Debug.Log(base.名前);
        }

        public override void 名乗り()
        {
            Debug.Log("私は子");
        }

        public override void 出身国()
        {
            Debug.Log(country);
        }
    }
}