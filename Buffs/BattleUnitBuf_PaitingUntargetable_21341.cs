using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mary_Ib21341.Passives;

namespace Mary_Ib21341.Buffs
{
    public class BattleUnitBuf_PaitingUntargetable_21341 : BattleUnitBuf
    {
        public override int SpeedDiceBreakedAdder()
        {
            return 10;
        }

        public override bool IsTargetable()
        {
            var maryUnit = BattleObjectManager.instance.GetAliveList(_owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_MaryNpc_21341>());
            return !maryUnit?.IsBreakLifeZero() ?? false;
        }
    }
}
