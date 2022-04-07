namespace Setsuna.Value
{
    public class BattleCharacterVO
    {
        public int Id { get; }
        public string BattleStep { get; }
        public float MinTime { get; }
        public float MaxTime { get; }

        public float ReflexTime { get; }

        public BattleCharacterVO(int id, string battleStep, float minTime, float maxTime, float reflexTime)
        {
            Id = id;
            BattleStep = battleStep;
            MinTime = minTime;
            MaxTime = maxTime;
            ReflexTime = reflexTime;
        }
    }
}