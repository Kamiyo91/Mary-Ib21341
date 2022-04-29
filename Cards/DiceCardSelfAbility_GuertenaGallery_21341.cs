using System.Linq;
using Mary_Ib21341.Passives;

namespace Mary_Ib21341.Cards
{
    public class DiceCardSelfAbility_GuertenaGallery_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            owner.allyCardDetail.DrawCards(1);
            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) !=
                1) return;
            owner.allyCardDetail.DrawCards(1);
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}