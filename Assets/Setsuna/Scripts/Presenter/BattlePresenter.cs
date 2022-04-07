using Setsuna.Value;

namespace Setsuna.Presenter
{
    public static class BattlePresenter
    {
        public static BattleCharacterVO GetBattleCharacter(int id)
        {
            switch (id)
            {
                default:
                    return new BattleCharacterVO(1, "BATTLE　1", 5f, 6f, 1f);
            }
        }
    }
}