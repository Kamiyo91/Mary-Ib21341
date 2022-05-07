using System.Linq;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
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
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoStaggerResist());
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
            _untargetableBuff.Mary = UnitUtil.AddNewUnitPlayerSide(_floor, new UnitModel
            {
                Id = 1,
                Name = ModParameters.NameTexts
                    .FirstOrDefault(x => x.Key.Equals(new LorId(MaryModParameters.PackageId, 1))).Value,
                EmotionLevel = _emotionLevel,
                Pos = 0,
                CustomPos = new XmlVector2 { x = 20, y = 0 }
            }, MaryModParameters.PackageId, false);
            _untargetableBuff.Mary.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoImmortalStagger());
        }
    }
}