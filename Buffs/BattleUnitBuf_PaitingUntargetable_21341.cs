using System.Linq;
using Mary_Ib21341.Passives;

namespace Mary_Ib21341.Buffs
{
    public class BattleUnitBuf_PaitingUntargetable_21341 : BattleUnitBuf
    {
        public BattleUnitModel Mary;

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            Mary = BattleObjectManager.instance.GetAliveList(_owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_MaryNpc_21341>());
        }

        public override int SpeedDiceBreakedAdder()
        {
            return 10;
        }

        public override bool IsTargetable()
        {
            return Mary?.IsBreakLifeZero() ?? false;
        }

        public override bool IsInvincibleHp(BattleUnitModel attacker)
        {
            return !Mary?.IsBreakLifeZero() ?? false;
        }
    }
}