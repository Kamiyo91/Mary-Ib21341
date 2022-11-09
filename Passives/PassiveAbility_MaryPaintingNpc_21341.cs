using System.Linq;
using BigDLL4221.Buffs;
using BigDLL4221.Utils;
using Mary_Ib21341.BLL;
using Mary_Ib21341.Buffs;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryPaintingNpc_21341 : PassiveAbilityBase
    {
        private readonly StageLibraryFloorModel
            _floor = Singleton<StageController>.Instance.GetCurrentStageFloorModel();

        private int _emotionLevel;
        private BattleUnitBuf_PaitingUntargetable_21341 _untargetableBuff;

        public override void OnWaveStart()
        {
            _emotionLevel = 0;
            owner.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL4221(false, true, true, true, infinite: true, lastOneScene: false,
                    isImmortal: false));
            owner.bufListDetail.AddBuf(new BattleUnitBuf_PaitingUntargetable_21341());
            _untargetableBuff = owner.bufListDetail.GetActivatedBufList()
                .First(x => x is BattleUnitBuf_PaitingUntargetable_21341) as BattleUnitBuf_PaitingUntargetable_21341;
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
                UnitUtil.UnitReviveAndRecovery(_untargetableBuff.Mary, _untargetableBuff.Mary.MaxHp, true);
            if (BattleObjectManager.instance.GetAliveList(owner.faction)
                .Exists(x => x.passiveDetail.HasPassive<PassiveAbility_MaryNpc_21341>())) return;
            _untargetableBuff.Mary = UnitUtil.AddNewUnitWithDefaultData(_floor, MaryModParameters.MaryNpcModel,
                BattleObjectManager.instance.GetList(owner.faction).Count, onWaveStartEffects: false);
            _untargetableBuff.Mary.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL4221(false, true, true, true, infinite: true, lastOneScene: false,
                    isImmortal: false));
            UnitUtil.CheckSkinProjection(_untargetableBuff.Mary);
            UnitUtil.RefreshCombatUI();
        }
    }
}