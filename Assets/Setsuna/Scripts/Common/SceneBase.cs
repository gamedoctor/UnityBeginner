using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setsuna
{
    public abstract class SceneBase<T> : MonoBehaviour, IScene where T : ISceneParameter, new()
    {
        private IEnumerator Start()
        {
            if (!SceneManager.Instance.StartInitialize)
            {
                SceneManager.Instance.StartInitialize = true;
                yield return OnPlay(new T());
            }
        }

        public IEnumerator OnPlay(ISceneParameter parameter)
        {
            OnInitialize();
            yield return OnApply(parameter);
        }

        public void OnInitialize()
        {
            Initialize();
        }

        public IEnumerator OnApply(ISceneParameter parameter)
        {
            yield return Apply((T) parameter);
        }

        protected abstract void Initialize();
        protected abstract IEnumerator Apply(T parameter);
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