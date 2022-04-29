using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
using Mary_Ib21341.Passives;

namespace Mary_Ib21341.Cards
{
    public class DiceCardSelfAbility_FakeFlower_21341 : DiceCardSelfAbilityBase
    {
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            Activate(unit);
            self.exhaust = true;
        }

        private static void Activate(BattleUnitModel unit)
        {
            var paitingUnit = BattleObjectManager.instance.GetAliveList(unit.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>());
            UnitUtil.RemoveDiceTargets(paitingUnit);
            paitingUnit?.RecoverHP(10);
            paitingUnit?.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoUntargetable());
        }

        public override bool IsTargetableAllUnit()
        {
            return true;
        }

        public override bool IsTargetableSelf()
        {
            return true;
        }
    }
}
