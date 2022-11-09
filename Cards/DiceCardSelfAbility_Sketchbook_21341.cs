using BigDLL4221.Utils;

namespace Mary_Ib21341.Cards
{
    public class DiceCardSelfAbility_Sketchbook_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            if (UnitUtil.SupportCharCheck(owner) != 1) return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 1
            });
        }
    }
}