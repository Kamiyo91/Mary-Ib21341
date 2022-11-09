using System.Linq;
using BigDLL4221.Utils;
using Mary_Ib21341.Buffs;
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
            if (paitingUnit == null) return;
            var paintingPassive =
                paitingUnit.passiveDetail.PassiveList.FirstOrDefault(x => x is PassiveAbility_MaryPainting_21341) as
                    PassiveAbility_MaryPainting_21341;
            UnitUtil.RemoveDiceTargets(paitingUnit, true);
            paintingPassive?.SetHitCount();
            paitingUnit.RecoverHP(10);
            paitingUnit.bufListDetail.AddBuf(new BattleUnitBuf_PaintingUntargetablePlayer_21341());
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