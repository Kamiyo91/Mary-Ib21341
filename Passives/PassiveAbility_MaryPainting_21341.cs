using System.Linq;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
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
        private UnitDataModel _unitData;

        public override void OnWaveStart()
        {
            _emotionLevel = 0;
            _hitCount = 0;
            _mary = BattleObjectManager.instance.GetAliveList(owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_Mary_21341>());
            owner.allyCardDetail.ExhaustAllCards();
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoStaggerResist());
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoCannotAct());
            _unitData = _mary?.UnitData.unitData;
            _pos = _mary?.index ?? 0;
        }

        public override void OnDie()
        {
            _mary?.Die();
        }

        public override void OnRoundEnd()
        {
            owner.breakDetail.RecoverBreak(owner.MaxBreakLife);
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
                ? UnitUtil.AddNewUnitWithPreUnitData(_floor, new UnitModel
                {
                    Name = ModParameters.NameTexts
                        .FirstOrDefault(x => x.Key.Equals(new LorId(MaryModParameters.PackageId, 1))).Value,
                    EmotionLevel = _emotionLevel,
                    Pos = BattleObjectManager.instance.GetList(Faction.Player).Count,
                    Sephirah = _floor.Sephirah
                }, _unitData)
                : _mary = UnitUtil.AddNewUnitWithPreUnitData(_floor, new UnitModel
                {
                    Name = ModParameters.NameTexts
                        .FirstOrDefault(x => x.Key.Equals(new LorId(MaryModParameters.PackageId, 1))).Value,
                    EmotionLevel = _emotionLevel,
                    Pos = BattleObjectManager.instance.GetList(Faction.Enemy).Count
                }, _unitData, false);
            _mary.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoImmortalStagger());
        }
    }
}