﻿using System.Collections.Generic;
using System.Linq;
using BigDLL4221.Buffs;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
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
            _paintingUnit = owner.faction == Faction.Player
                ? UnitUtil.AddNewUnitWithDefaultData(_floor, MaryModParameters.PaintingPlayerModel,
                    BattleObjectManager.instance.GetAliveList(Faction.Player).Count)
                : _paintingUnit = UnitUtil.AddNewUnitWithDefaultData(_floor,
                    MaryModParameters.PaintingPlayerModelReverse,
                    BattleObjectManager.instance.GetAliveList(Faction.Enemy).Count, playerSide: false);
            if (Singleton<StageController>.Instance.GetStageModel()
                .GetStageStorageData<float>($"MaryPaintingHp21341{owner.faction}", out var paintingHp))
                _paintingUnit.SetHp((int)paintingHp);
            owner.bufListDetail.AddBuf(
                new BattleUnitBuf_Immortal_DLL4221(false, true, true, infinite: true, lastOneScene: false));
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
                AbColorType.Negative);
            _staggered = true;
        }
    }
}