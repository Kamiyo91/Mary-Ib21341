using UtilLoader21341.Util;

namespace Mary_Ib21341.Cards
{
    public class DiceCardSelfAbility_LostHope_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.ChangeCardCostByValue(-1, 3, false);
            if (UnitUtil.SupportCharCheck(owner) != 1) return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 8
            });
        }
    }
}