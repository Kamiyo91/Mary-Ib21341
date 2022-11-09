using BigDLL4221.Utils;

namespace Mary_Ib21341.Cards
{
    public class DiceCardSelfAbility_GuertenaGallery_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            if (UnitUtil.SupportCharCheck(owner) != 1) return;
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}