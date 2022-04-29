using System.Linq;
using KamiyoStaticUtil.Utils;
using Mary_Ib21341.Passives;

namespace Mary_Ib21341.Cards
{
    public class DiceCardSelfAbility_LostHope_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseCard()
        {
            if (BattleObjectManager.instance.GetAliveList(UnitUtil.ReturnOtherSideFaction(owner.faction)).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) == 1)
                UnitUtil.ChangeCardCostByValue(owner, -1, 99);
            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) !=
                1) return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                power = 8
            });
        }
    }
}