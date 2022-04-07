using System.Collections;
using Setsuna.Value;
using UnityEngine;
using UnityEngine.UI;

namespace Setsuna
{
    public class BattleView : MonoBehaviour
    {
        public delegate Speaker.StopAction PlaySound(AudioClip audioClip);

        public class Parameter
        {
            public BattleCharacterVO BattleCharacter { get; }
            public PlaySound OnPlaySound { get; }

            public Parameter(BattleCharacterVO battleCharacter, PlaySound onPlaySound)
            {
                BattleCharacter = battleCharacter;
                OnPlaySound = onPlaySound;
            }
        }

        [SerializeField] private Text battleStepText;
        [SerializeField] private Text timerText;

        private PlaySound onPlaySound;
        private float waitTime;
        private float reflexTime;

        public void Initialize()
        {
            battleStepText.text = string.Empty;
            timerText.text = string.Empty;
        }

        public IEnumerator Apply(Parameter parameter)
        {
            battleStepText.text = parameter.BattleCharacter.BattleStep;
            timerText.text = "0.0";
            onPlaySound = parameter.OnPlaySound;
            waitTime = UnityEngine.Random.Range(parameter.BattleCharacter.MinTime, parameter.BattleCharacter.MaxTime);
            reflexTime = parameter.BattleCharacter.ReflexTime;
            yield return null;
        }

        public IEnumerator Play()
        {
            var stop = onPlaySound(Resources.Load<AudioClip>("Sounds/battle"));
            var time = waitTime;
            var current = 0f;
            while (current < time)
            {
                current += Time.deltaTime;
                yield return null;
            }

            stop();
            var win = false;
            var counter = false;
            time = reflexTime;
            current = 0f;
            while (current < time)
            {
                current += Time.deltaTime;
                timerText.text = current.ToString("F3");
                if (Input.GetMouseButtonDown(0))
                {
                    win = true;
                    break;
                }

                yield return null;
            }

            if (!win)
            {
                time = 0.1f;
                current = 0f;
                while (current < time)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        counter = true;
                        break;
                    }

                    yield return null;
                }
            }

            onPlaySound(Resources.Load<AudioClip>("Sounds/se"));
        }
    }
}