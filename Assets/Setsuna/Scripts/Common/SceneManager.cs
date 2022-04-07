using System;
using UnityEngine;

namespace Setsuna
{
    public class SceneManager : SingletonMonoBehaviour<SceneManager>
    {
        private bool startInitialize = false; 
        public bool StartInitialize
        {
            get
            {
                return startInitialize;
            }
            set
            {
                if (startInitialize)
                {
                    throw new Exception("１度しか更新してはいけない");
                }

                if (!value)
                {
                    throw new Exception("false代入禁止");
                }

                startInitialize = value;
            }
        }
    }
}