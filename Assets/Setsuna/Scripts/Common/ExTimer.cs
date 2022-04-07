using System;
using System.Collections;
using UnityEngine;

namespace Setsuna
{
    public static class ExTimer
    {
        public delegate void Loop(float rate);
        
        public static IEnumerator Run(float time, Loop loop)
        {
            var current = 0f;
            while (current < time)
            {
                current += Time.deltaTime;
                loop(Mathf.Clamp01(current / time));
                yield return null;
            }
        }
    }
}