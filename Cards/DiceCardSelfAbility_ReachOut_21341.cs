using BigDLL4221.Utils;

namespace Mary_Ib21341.Cards
{
    public class DiceCardSelfAbility_ReachOut_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
            if (UnitUtil.SupportCharCheck(owner) != 1) return;
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}