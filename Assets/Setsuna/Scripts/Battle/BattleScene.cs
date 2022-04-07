using System.Collections;
using System.Collections.Generic;
using Setsuna.Presenter;
using Setsuna.Value;
using UnityEngine;

namespace Setsuna
{
    public class BattleScene : SceneBase<BattleScene.SceneParameter>
    {
        public class SceneParameter : ISceneParameter
        {
            public int SceneId => 1;

            public BattleCharacterVO BattleCharacter { get; }

            public SceneParameter()
            {
                BattleCharacter = BattlePresenter.GetBattleCharacter(1);
            }
        }

        [SerializeField] private ReadyView readyView;
        [SerializeField] private BattleView battleView;
        [SerializeField] private Speaker speaker;

        protected override void Initialize()
        {
            Application.targetFrameRate = 60;
            readyView.Initialize();
            battleView.Initialize();
            speaker.Initialize();
        }

        protected override IEnumerator Apply(SceneParameter parameter)
        {
            yield return new Enumerators(
                readyView.Apply(new ReadyView.Parameter(parameter.BattleCharacter.BattleStep)),
                battleView.Apply(new BattleView.Parameter(parameter.BattleCharacter, clip => speaker.Play(clip, 0)))
            );
        }

        protected override IEnumerator In()
        {
            yield return new WaitForSeconds(1f);
            yield return readyView.In();
            StartCoroutine(battleView.Play());
        }
    }
}