using System.Linq;
using CustomMapUtility;
using Mary_Ib21341.BLL;
using Mary_Ib21341.Buffs;
using UtilLoader21341.Extensions;
using UtilLoader21341.Util;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryPaintingNpc_21341 : PassiveAbilityBase
    {
        private readonly CustomMapHandler _cmh = CustomMapHandler.GetCMU(MaryModParameters.PackageId);
        private int _emotionLevel;
        private bool _mapActive;
        private BattleUnitBuf_PaitingUntargetable_21341 _untargetableBuff;

        public override void OnWaveStart()
        {
            if (Singleton<StageController>.Instance.GetStageModel().ClassInfo.id.packageId ==
                MaryModParameters.PackageId &&
                Singleton<StageController>.Instance.GetStageModel().ClassInfo.id.id == 1) OnWaveStartMap();
            _emotionLevel = 0;
            owner.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL21341(false, true, true, infinite: true, lastOneScene: false,
                    isImmortal: false));
            owner.bufListDetail.AddBuf(new BattleUnitBuf_PaitingUntargetable_21341());
            _untargetableBuff = owner.bufListDetail.GetActivatedBufList()
                .First(x => x is BattleUnitBuf_PaitingUntargetable_21341) as BattleUnitBuf_PaitingUntargetable_21341;
        }

        public void OnWaveStartMap()
        {
            _mapActive = true;
            MapUtil.InitEnemyMap<Mary_21341MapManager>(_cmh, MaryModParameters.MaryMapModel);
        }

        public override void OnRoundStartAfter()
        {
            if (_mapActive) _cmh.EnforceMap();
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

        public override void OnRoundEndTheLast()
        {
            if (_untargetableBuff == null) return;
            _emotionLevel = _untargetableBuff.Mary?.emotionDetail.EmotionLevel ?? _emotionLevel;
            if (_untargetableBuff.Mary?.IsDead() ?? false)
                _untargetableBuff.Mary.UnitReviveAndRecovery(_untargetableBuff.Mary.MaxHp, true);
            if (BattleObjectManager.instance.GetAliveList(owner.faction)
                .Exists(x => x.passiveDetail.HasPassive<PassiveAbility_MaryNpc_21341>())) return;
            _untargetableBuff.Mary = UnitUtil.AddNewUnitWithDefaultData(MaryModParameters.MaryNpcModel,
                BattleObjectManager.instance.GetList(owner.faction).Count, onWaveStartEffects: false,
                unitSide: owner.faction);
            _untargetableBuff.Mary.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL21341(false, true, true, infinite: true, lastOneScene: false,
                    isImmortal: false));
            UnitUtil.CheckSkinProjection(_untargetableBuff.Mary);
            UnitUtil.RefreshCombatUI();
        }
    }
}