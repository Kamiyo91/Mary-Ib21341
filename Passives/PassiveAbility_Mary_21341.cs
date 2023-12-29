using System.Collections.Generic;
using System.Linq;
using LOR_XML;
using Mary_Ib21341.BLL;
using UnityEngine;
using UtilLoader21341;
using UtilLoader21341.Extensions;
using UtilLoader21341.Util;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_Mary_21341 : PassiveAbilityBase
    {
        private BattleUnitModel _paintingUnit;
        private bool _staggered;

        public override void OnWaveStart()
        {
            if (owner.GetActivePassive<PassiveAbility_CanRedirectPassive_DLL21341>() == null)
            {
                var passive = new PassiveAbility_CanRedirectPassive_DLL21341();
                owner.passiveDetail.AddPassive(passive);
                passive.SetKeyword("MaryPaintingPlayer_21341");
            }

            _paintingUnit = UnitUtil.AddNewUnitWithDefaultData(MaryModParameters.PaintingPlayerModel,
                BattleObjectManager.instance.GetAliveList(owner.faction).Count, unitSide: owner.faction);
            if (Singleton<StageController>.Instance.GetStageModel()
                .GetStageStorageData<float>($"MaryPaintingHp21341{owner.faction}", out var paintingHp))
                _paintingUnit.SetHp((int)paintingHp);
            owner.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL21341(false, true, true, infinite: true, lastOneScene: false));
            owner.RecoverHP(owner.MaxHp);
            UnitUtil.CheckSkinProjection(owner);
            UnitUtil.RefreshCombatUI();
        }

        public override void OnRoundStartAfter()
        {
            owner.personalEgoDetail.RemoveCard(new LorId(MaryModParameters.PackageId, 2));
            owner.personalEgoDetail.AddCard(new LorId(MaryModParameters.PackageId, 2));
            owner.personalEgoDetail.GetCardAll()
                .FirstOrDefault(x => x.GetID() == new LorId(MaryModParameters.PackageId, 2))?.AddCost(-4);
            if (!_staggered) return;
            _staggered = false;
            owner.bufListDetail.AddBuf(new BattleUnitBuf_LockedUnit_DLL21341());
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
                new Color(0.5f, 0, 0, 1f));
            owner.RecoverHP(owner.MaxHp);
        }

        public override void OnBattleEnd()
        {
            var stageModel = Singleton<StageController>.Instance.GetStageModel();
            stageModel.SetStageStorgeData($"MaryPaintingHp21341{owner.faction}", _paintingUnit.hp);
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
                new Color(0.5f, 0, 0, 1f));
            _staggered = true;
        }
    }
}