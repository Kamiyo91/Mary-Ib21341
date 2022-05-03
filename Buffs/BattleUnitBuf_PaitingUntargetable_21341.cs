using System.Linq;
using Mary_Ib21341.Passives;

namespace Mary_Ib21341.Buffs
{
    public class BattleUnitBuf_PaitingUntargetable_21341 : BattleUnitBuf
    {
        private BattleUnitModel _mary;

        public override void Init(BattleUnitModel owner)
        {
            base.Init(owner);
            _mary = BattleObjectManager.instance.GetAliveList(_owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_MaryNpc_21341>());
        }

        public override int SpeedDiceBreakedAdder()
        {
            return 10;
        }

        public override bool IsTargetable()
        {
            return _mary?.IsBreakLifeZero() ?? false;
        }

        public override bool IsInvincibleHp(BattleUnitModel attacker)
        {
            return !_mary?.IsBreakLifeZero() ?? false;
        }
    }
}