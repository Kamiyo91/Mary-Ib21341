using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamiyoStaticBLL.Enums;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
using LOR_XML;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_GuertenaArt_21341 : PassiveAbilityBase
    {
        private readonly StageLibraryFloorModel
            _floor = Singleton<StageController>.Instance.GetCurrentStageFloorModel();

        private int _count = 1;
        public override void OnWaveStart()
        {
            _count = 1;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, _count);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, _count);
        }

        public override void OnRoundEnd()
        {
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, _count);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, _count);
            if (BattleObjectManager.instance.GetAliveList(UnitUtil.ReturnOtherSideFaction(owner.faction)).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) == 1)
            {
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 1);
            }
            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) && !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() && !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) !=
                1) return;
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 1);
        }

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (_floor.Sephirah == SephirahType.Netzach)
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    min = 1,
                    max = 1
                });
        }
        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (owner.hp < 2)
                owner.breakDetail.LoseBreakLife(attacker);
        }

        public override void OnBreakState()
        {
            UnitUtil.ChangeCardCostByValue(owner,-1,99);
            UnitUtil.BattleAbDialog(owner.view.dialogUI, new List<AbnormalityCardDialog>
                {
                    new AbnormalityCardDialog{id = "MaryBreak",dialog = ModParameters.EffectTexts.FirstOrDefault(x => x.Key.Equals("MaryBreak1")).Value
                        .Desc}
                },
                AbColorType.Negative);
            owner.bufListDetail.AddBuf(new BattleUnitBuf_KamiyoLockedUnit());
            if (_count < 2) _count++;
        }
    }
}
