using KamiyoStaticUtil.Utils;

namespace Mary_Ib21341.Cards
{
    public class DiceCardSelfAbility_LostHope_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            UnitUtil.ChangeCardCostByValue(owner, -1, 3);
            if (UnitUtil.SupportCharCheck(owner) != 1) return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 8
            });
        }
    }
}