using UtilLoader21341.Util;

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
            if (UnitUtil.SupportCharCheck(owner, true) < 2)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1);
            }

            if (UnitUtil.SupportCharCheck(owner) != 1) return;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1);
        }

        public override void OnRoundEnd()
        {
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, _count);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, _count);
            if (UnitUtil.SupportCharCheck(owner, true) < 2)
            {
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 1);
            }

            if (UnitUtil.SupportCharCheck(owner) > 1) return;
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 1);
        }

        public override void OnBreakState()
        {
            owner.ChangeCardCostByValue(-1, 99, false);
            if (_count < 4) _count++;
        }
    }
}