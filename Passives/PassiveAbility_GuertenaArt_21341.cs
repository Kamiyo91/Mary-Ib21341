using System.Collections.Generic;
using System.Linq;
using KamiyoStaticBLL.Enums;
using KamiyoStaticBLL.Models;
using KamiyoStaticUtil.CommonBuffs;
using KamiyoStaticUtil.Utils;
using LOR_XML;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_GuertenaArt_21341 : PassiveAbilityBase
    {
        private int _count = 1;

        public override void OnWaveStart()
        {
            _count = 1;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, _count);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, _count);
            if (BattleObjectManager.instance.GetAliveList(UnitUtil.ReturnOtherSideFaction(owner.faction)).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) == 1)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1);
            }

            if (BattleObjectManager.instance.GetAliveList(owner.faction).Count(x =>
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) !=
                1) return;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1);
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
                    !x.passiveDetail.PassiveList.Exists(y => y.id == new LorId("LorModPackRe21341.Mod", 57)) &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPainting_21341>() &&
                    !x.passiveDetail.HasPassive<PassiveAbility_MaryPaintingNpc_21341>()) !=
                1) return;
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 1);
        }

        public override void OnBreakState()
        {
            UnitUtil.ChangeCardCostByValue(owner, -1, 99);
            if (_count < 2) _count++;
        }
    }
}