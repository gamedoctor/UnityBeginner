using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Setsuna
{
    public class ReadyView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Text battleStepText;

        public class Parameter
        {
            public string BattleStepText { get; }

            public Parameter(string battleStepText)
            {
                BattleStepText = battleStepText;
            }
        }

        public void Initialize()
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 1f;
        }

        public IEnumerator Apply(Parameter parameter)
        {
            battleStepText.text = parameter.BattleStepText;
            yield return null;
        }

        public IEnumerator In()
        {
            yield return ExTimer.Run(0.1f, rate => canvasGroup.alpha = ExAnimation.EaseOut(1, 0, rate));
            gameObject.SetActive(false);
        }
    }
}