using System.Collections.Generic;
using System.Linq;
using KamiyoStaticBLL.Enums;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
using LOR_XML;
using Mary_Ib21341.BLL;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_Mary_21341 : PassiveAbilityBase
    {
        private readonly StageLibraryFloorModel
            _floor = Singleton<StageController>.Instance.GetCurrentStageFloorModel();

        private BattleUnitModel _paintingUnit;

        private bool _staggered;

        public override void OnWaveStart()
        {
            owner.RecoverHP(owner.MaxHp);
            _paintingUnit = UnitUtil.AddNewUnitPlayerSide(_floor, new UnitModel
            {
                Id = 10000002,
                Name = ModParameters.NameTexts
                    .FirstOrDefault(x => x.Key.Equals(new LorId(MaryModParameters.PackageId, 2))).Value,
                EmotionLevel = 0,
                Pos = 5,
                Sephirah = _floor.Sephirah,
                CustomPos = new XmlVector2 { x = 20, y = 0 }
            }, MaryModParameters.PackageId);
            if (Singleton<StageController>.Instance.GetStageModel()
                .GetStageStorageData<float>("MaryPaintingHp21341", out var paintingHp))
                _paintingUnit.SetHp((int)paintingHp);
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoImmortalStagger());
            UnitUtil.RefreshCombatUI();
        }

        public override void OnRoundStartAfter()
        {
            owner.personalEgoDetail.RemoveCard(new LorId(MaryModParameters.PackageId, 2));
            owner.personalEgoDetail.AddCard(new LorId(MaryModParameters.PackageId, 2));
            if (!_staggered) return;
            _staggered = false;
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoLockedUnit());
        }

        public override void OnRoundEnd()
        {
            owner.breakDetail.RecoverBreak(owner.MaxBreakLife);
        }

        public override void OnDie()
        {
            _paintingUnit.Die();
        }

        public override void OnKill(BattleUnitModel target)
        {
            UnitUtil.BattleAbDialog(owner.view.dialogUI, new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog
                    {
                        id = "MaryKill", dialog = ModParameters.EffectTexts
                            .FirstOrDefault(x => x.Key.Equals("MaryKill1_21341")).Value
                            .Desc
                    }
                },
                AbColorType.Negative);
            owner.RecoverHP(owner.MaxHp);
        }

        public override void OnBattleEnd()
        {
            var stageModel = Singleton<StageController>.Instance.GetStageModel();
            stageModel.SetStageStorgeData("MaryPaintingHp21341", _paintingUnit.hp);
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
                        id = "MaryBreak", dialog = ModParameters.EffectTexts
                            .FirstOrDefault(x => x.Key.Equals("MaryBreak1_21341")).Value
                            .Desc
                    }
                },
                AbColorType.Negative);
            _staggered = true;
        }
    }
}