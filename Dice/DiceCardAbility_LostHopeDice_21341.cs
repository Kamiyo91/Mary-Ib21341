using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mary_Ib21341.Passives;

namespace Mary_Ib21341.Dice
{
    public class DiceCardAbility_LostHopeDice_21341 : DiceCardAbilityBase
    {
        public override void OnWinParrying()
        {
            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) !=
                1) return;
            if (card?.target?.currentDiceAction?.cardBehaviorQueue.Count > 0)
                card?.target?.currentDiceAction?.DestroyDice(DiceMatch.AllDice, DiceUITiming.AttackAfter);
        }
    }
}
