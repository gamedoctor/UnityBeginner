using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Setsuna
{
    public class Speaker : MonoBehaviour
    {
        public delegate void StopAction();

        private List<AudioSource> sources = new List<AudioSource>();

        public void Initialize()
        {
            for (var i = 0; i < 10; i++)
            {
                var source = gameObject.AddComponent<AudioSource>();
                source.volume = 0.3f;
                sources.Add(source);
            }
        }

        public StopAction Play(AudioClip audioClip, double gap)
        {
            var source = sources.FirstOrDefault(x => !x.isPlaying);
            if (source == null)
            {
                source = gameObject.AddComponent<AudioSource>();
            }

            source.clip = audioClip;
            source.PlayScheduled(gap);
            StartCoroutine(Execute());

            return () => source.Stop();

            IEnumerator Execute()
            {
                yield return new WaitWhile(() => source.isPlaying);
                source.clip = null;
            }
        }
    }
}