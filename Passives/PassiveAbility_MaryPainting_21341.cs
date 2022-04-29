using System.Linq;
using KamiyoStaticUtil.CommonBuffs;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryPainting_21341 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            owner.allyCardDetail.ExhaustAllCards();
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoImmortalStagger());
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoCannotAct());
        }

        public override void OnDie()
        {
            BattleObjectManager.instance.GetAliveList(owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_Mary_21341>())
                ?.Die();
        }

        public override void OnRoundEnd()
        {
            owner.breakDetail.RecoverBreak(owner.MaxBreakLife);
        }
    }
}