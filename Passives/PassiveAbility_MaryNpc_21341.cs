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
            _paintingUnit = UnitUtil.AddNewUnitEnemySide(new UnitModel
            {
                Id = 2,
                EmotionLevel = 0,
                LockedEmotion = true,
                Pos = 1,
                CustomPos = new XmlVector2 { x = 20, y = 0 },
                OnWaveStart = true
            }, MaryModParameters.PackageId);
            if (Singleton<StageController>.Instance.GetStageModel()
                .GetStageStorageData<float>("MaryPaintingNpcHp21341", out var paintingHp))
                _paintingUnit.SetHp((int)paintingHp);
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoImmortalStagger());
            UnitUtil.RefreshCombatUI();
        }

        public override void OnRoundStartAfter()
        {
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
            BattleObjectManager.instance.GetAliveList(owner.faction)
                .FirstOrDefault(x => x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>())
                ?.Die();
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
            stageModel.SetStageStorgeData("MaryPaintingNpcHp21341", _paintingUnit.hp);
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