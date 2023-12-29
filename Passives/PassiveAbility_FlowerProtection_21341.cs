using Mary_Ib21341.BLL;
using UtilLoader21341.Util;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_FlowerProtection_21341 : PassiveAbilityBase
    {
        public override void OnStartBattle()
        {
            owner.ReadyCounterCard(6, MaryModParameters.PackageId);
        }
    }
}