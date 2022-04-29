using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
using Mary_Ib21341.Buffs;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryPaintingNpc_21341 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoImmortalStagger());
            UnitUtil.RemoveDiceTargets(owner);
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
