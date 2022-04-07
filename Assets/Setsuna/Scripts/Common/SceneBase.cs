using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setsuna
{
    public abstract class SceneBase<T> : MonoBehaviour, IScene where T : ISceneParameter, new()
    {
        // バトルシーンはここから開始する
        private IEnumerator Start()
        {
            // 1回きりしか実行しないようにしている
            // if文は条件式、true(真)である場合、ifの中身を実行する
            // bool型 = 真偽値　真(true)or偽(false)
            // ツクール語でいうとスイッチOFFである場合
            // スイッチON = true, スイッチOFF = false
            if (!SceneManager.Instance.StartInitialize)
            {
                // StartInitializeが終わったことを記述する
                // ツクール語でいうとスイッチONにした
                SceneManager.Instance.StartInitialize = true;
                // 関数`OnPlay`を実行する
                // 引数については説明を割愛
                yield return OnPlay(new T());
            }
        }

        public IEnumerator OnPlay(ISceneParameter parameter)
        {
            // 関数`OnInitialize`を実行する
            OnInitialize();
            // 関数`OnApply`を実行する
            yield return OnApply(parameter);
        }

        public void OnInitialize()
        {
            // 関数`Initialize`を実行する
            Initialize();
        }

        public IEnumerator OnApply(ISceneParameter parameter)
        {
            yield return Apply((T) parameter);
            yield return In();
        }

        protected abstract void Initialize();
        protected abstract IEnumerator Apply(T parameter);
        protected abstract IEnumerator In();
    }

    public interface ISceneParameter
    {
        public int SceneId { get; }
    }

    public interface IScene
    {
        IEnumerator OnPlay(ISceneParameter parameter);
        void OnInitialize();
        IEnumerator OnApply(ISceneParameter parameter);
    }
}