using UnityEngine;

namespace Setsuna
{
    public static class ExAnimation
    {
        private static AnimationCurve EaseInOut { get; } = AnimationCurve.EaseInOut(0, 0, 1, 1);

        public static float EaseIn(float rate)
        {
            // 0.0 ~ 0.5
            return (EaseInOut.Evaluate(Mathf.Lerp(0f, 0.5f, rate))) * 2;
        }

        public static float EaseOut(float rate)
        {
            // 0.5 ~ 1.0
            return (EaseInOut.Evaluate(Mathf.Lerp(0.5f, 1f, rate)) - 0.5f) * 2;
        }

        public static Vector3 EaseOut(Vector3 s, Vector3 e, float rate)
        {
            return Vector3.Lerp(s, e, EaseOut(rate));
        }

        public static float EaseOut(float s, float e, float rate)
        {
            return Mathf.Lerp(s, e, EaseOut(rate));
        }
    }
}