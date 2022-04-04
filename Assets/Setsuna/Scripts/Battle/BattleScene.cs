using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setsuna
{
    public class BattleScene : SceneBase<BattleScene.SceneParameter>
    {
        public class SceneParameter : ISceneParameter
        {
            public int SceneId => 1;
            
            // ここに必要なパラメータを追加する

            public SceneParameter()
            {
                // ここに必要なパラメータの処理を書く
            }
        }

        protected override void Initialize()
        {
            // 初期化処理を書く
        }

        protected override IEnumerator Apply(SceneParameter parameter)
        {
            // 反映処理を書く
            yield return null;
        }
    }

}

