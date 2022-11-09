using System.Linq;
using BigDLL4221.Buffs;
using BigDLL4221.Utils;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryPainting_21341 : PassiveAbilityBase
    {
        private const int BaseCost = 6;

        private readonly StageLibraryFloorModel
            _floor = Singleton<StageController>.Instance.GetCurrentStageFloorModel();

        private int _emotionLevel;
        private int _hitCount;
        private BattleUnitModel _mary;
        private int _pos;

        public override void OnWaveStart()
        {
            _emotionLevel = 0;
            _hitCount = 0;
            _mary = BattleObjectManager.instance.GetAliveList(owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_Mary_21341>());
            owner.allyCardDetail.ExhaustAllCards();
            owner.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL4221(false, true, true, true, infinite: true, lastOneScene: false,
                    isImmortal: false));
            owner.bufListDetail.AddBuf(new BattleUnitBuf_LockedUnit_DLL4221(infinite: true, lastOneScene: false));
            _pos = _mary?.index ?? 0;
        }

        public override void OnDie()
        {
            _mary?.Die();
        }

        public override void OnRoundEnd()
        {
            owner.breakDetail.RecoverBreak(owner.MaxBreakLife);
            _hitCount++;
        }

        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (dmg > 0) _hitCount++;
        }

        public override void OnRoundStartAfter()
        {
            _mary?.personalEgoDetail.RemoveCard(new LorId(MaryModParameters.PackageId, 2));
            _mary?.personalEgoDetail.AddCard(new LorId(MaryModParameters.PackageId, 2));
            _mary?.personalEgoDetail.GetCardAll()
                .FirstOrDefault(x => x.GetID() == new LorId(MaryModParameters.PackageId, 2))
                ?.SetCurrentCost(BaseCost - _hitCount);
        }

        public void SetHitCount()
        {
            _hitCount = 0;
        }

        public override void OnRoundEndTheLast()
        {
            _emotionLevel = _mary?.emotionDetail.EmotionLevel ?? _emotionLevel;
            if (_mary?.IsDead() ?? false)
                UnitUtil.UnitReviveAndRecovery(_mary, _mary.MaxHp, true);
            if (BattleObjectManager.instance.GetAliveList(owner.faction)
                .Exists(x => x.passiveDetail.HasPassive<PassiveAbility_Mary_21341>())) return;
            _mary = owner.faction == Faction.Player
                ? UnitUtil.AddNewUnitWithDefaultData(_floor, MaryModParameters.MaryPlayerModel,
                    _pos, onWaveStartEffects: false)
                : _mary = UnitUtil.AddNewUnitWithDefaultData(_floor, MaryModParameters.MaryPlayerModel,
                    _pos, onWaveStartEffects: false);
            _mary.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL4221(false, true, true, true, infinite: true, lastOneScene: false,
                    isImmortal: false));
            UnitUtil.CheckSkinProjection(_mary);
            UnitUtil.RefreshCombatUI();
        }
    }
}