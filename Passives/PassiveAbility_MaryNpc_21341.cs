using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryNpc_21341 : PassiveAbilityBase
    {
        private readonly StageLibraryFloorModel
           _floor = Singleton<StageController>.Instance.GetCurrentStageFloorModel();
        private BattleUnitModel _paintingUnit;
        public override void OnWaveStart()
        {
            owner.RecoverHP(owner.MaxHp);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1);
            _paintingUnit = UnitUtil.AddNewUnitEnemySide(new UnitModel
            {
                Id = 2,
                EmotionLevel = 0,
                MaxEmotionLevel = 0,
                Pos = 1,
                OnWaveStart = true
            }, MaryModParameters.PackageId);
            if (Singleton<StageController>.Instance.GetStageModel()
                .GetStageStorageData<float>("MaryPaintingNpcHp21341", out var paintingHp))
                _paintingUnit.SetHp((int)paintingHp);
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoImmortalStagger());
        }

        public override void OnRoundEnd()
        {
            owner.breakDetail.RecoverBreak(owner.MaxBreakLife);
        }
        public override void OnDie()
        {
            BattleObjectManager.instance.GetAliveList(owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>())
                ?.Die();
        }

        public override void OnKill(BattleUnitModel target)
        {
            owner.RecoverHP(owner.MaxHp);
        }

        public override void OnBattleEnd()
        {
            var stageModel = Singleton<StageController>.Instance.GetStageModel();
            stageModel.SetStageStorgeData("MaryPaintingNpcHp21341", _paintingUnit.hp);
        }
    }
}
