using System.Linq;
using KamiyoStaticUtil.CommonBuffs;
using Mary_Ib21341.Buffs;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryPaintingNpc_21341 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoStaggerResist());
            owner.bufListDetail.AddBuf(new BattleUnitBuf_PaitingUntargetable_21341());
        }

        public override void OnDie()
        {
            BattleObjectManager.instance.GetAliveList(owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_MaryNpc_21341>())
                ?.Die();
        }

        public override void OnRoundEnd()
        {
            owner.breakDetail.RecoverBreak(owner.MaxBreakLife);
        }
    }
}