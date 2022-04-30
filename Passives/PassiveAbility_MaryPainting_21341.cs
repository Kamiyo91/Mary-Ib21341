using System.Linq;
using KamiyoStaticUtil.CommonBuffs;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryPainting_21341 : PassiveAbilityBase
    {
        private BattleUnitModel _mary;
        private int _hitCount;
        private const int BaseCost = 6;

        public override void OnWaveStart()
        {
            _hitCount = 0;
            _mary = BattleObjectManager.instance.GetAliveList(owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_Mary_21341>());
            owner.allyCardDetail.ExhaustAllCards();
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoStaggerResist());
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoCannotAct());
        }

        public override void OnDie()
        {
            _mary.Die();
        }

        public override void OnRoundEnd()
        {
            owner.breakDetail.RecoverBreak(owner.MaxBreakLife);
        }

        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            _hitCount++;
        }
        public override void OnRoundStartAfter()
        {
            _mary.personalEgoDetail.RemoveCard(new LorId(MaryModParameters.PackageId, 2));
            _mary.personalEgoDetail.AddCard(new LorId(MaryModParameters.PackageId, 2));
            _mary.personalEgoDetail.GetCardAll().FirstOrDefault(x => x.GetID() == new LorId(MaryModParameters.PackageId, 2))?.SetCurrentCost(BaseCost - _hitCount);
        }
        public void SetHitCount() => _hitCount = 0;
    }
}