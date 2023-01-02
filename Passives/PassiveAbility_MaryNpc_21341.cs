using System.Collections.Generic;
using System.Linq;
using BigDLL4221.Buffs;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_XML;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_MaryNpc_21341 : PassiveAbilityBase
    {
        private BattleUnitModel _paintingUnit;
        private bool _staggered;

        public override int SpeedDiceNumAdder()
        {
            return 2;
        }

        public override void OnWaveStart()
        {
            owner.RecoverHP(owner.MaxHp);
            _paintingUnit = UnitUtil.AddNewUnitWithDefaultData(MaryModParameters.PaintingNpcModel,
                BattleObjectManager.instance.GetList(owner.faction).Count, unitSide: owner.faction);
            if (Singleton<StageController>.Instance.GetStageModel()
                .GetStageStorageData<float>("MaryPaintingNpcHp21341", out var paintingHp))
                _paintingUnit.SetHp((int)paintingHp);
            owner.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL4221(false, true, true, infinite: true, lastOneScene: false));
            UnitUtil.RefreshCombatUI();
        }

        public override void OnRoundStartAfter()
        {
            if (!_staggered) return;
            _staggered = false;
            owner.bufListDetail.AddBuf(new BattleUnitBuf_LockedUnit_DLL4221());
        }

        public override void OnRoundEnd()
        {
            owner.breakDetail.RecoverBreak(owner.MaxBreakLife);
        }

        public override void OnKill(BattleUnitModel target)
        {
            UnitUtil.BattleAbDialog(owner.view.dialogUI, new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "MaryKill", dialog = ModParameters.LocalizedItems[MaryModParameters.PackageId].EffectTexts
                            .FirstOrDefault(x => x.Key.Equals("MaryKill1_21341")).Value
                            .Desc
                    }
                },
                AbColorType.Negative);
            owner.RecoverHP(owner.MaxHp);
        }

        //public override void OnBattleEnd()
        //{
        //    var stageModel = Singleton<StageController>.Instance.GetStageModel();
        //    stageModel.SetStageStorgeData("MaryPaintingNpcHp21341", _paintingUnit.hp);
        //}
        public override void OnBattleEnd()
        {
            var stageModel = Singleton<StageController>.Instance.GetStageModel();
            var index = 0;
            foreach (var unit in BattleObjectManager.instance.GetAliveList(owner.faction)
                         .Where(x => x.passiveDetail.HasPassive<PassiveAbility_MaryNpc_21341>()))
            {
                stageModel.SetStageStorgeData($"SavedUnitDataHP_{owner.faction}_{index}", unit.hp);
                stageModel.SetStageStorgeData($"SavedUnitDataEmotionLevel_{owner.faction}_{index}",
                    unit.emotionDetail.EmotionLevel);
                index++;
            }
        }

        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (owner.hp < 2)
                owner.breakDetail.LoseBreakLife(attacker);
        }

        public override void OnReleaseBreak()
        {
            owner.RecoverHP(owner.MaxHp);
        }

        public override void OnBreakState()
        {
            UnitUtil.BattleAbDialog(owner.view.dialogUI, new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "MaryBreak", dialog = ModParameters.LocalizedItems[MaryModParameters.PackageId].EffectTexts
                            .FirstOrDefault(x => x.Key.Equals("MaryBreak1_21341")).Value
                            .Desc
                    }
                },
                AbColorType.Negative);
            _staggered = true;
        }
    }
}