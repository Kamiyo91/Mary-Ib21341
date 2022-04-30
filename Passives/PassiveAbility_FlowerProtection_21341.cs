using KamiyoStaticUtil.Utils;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_FlowerProtection_21341 : PassiveAbilityBase
    {
        public override void OnStartBattle()
        {
            UnitUtil.ReadyCounterCard(owner, 6, MaryModParameters.PackageId);
        }
    }
}
