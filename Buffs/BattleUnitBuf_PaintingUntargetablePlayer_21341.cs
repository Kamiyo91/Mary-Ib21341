namespace Mary_Ib21341.Buffs
{
    public class BattleUnitBuf_PaintingUntargetablePlayer_21341 : BattleUnitBuf
    {
        public override bool IsTargetable()
        {
            return false;
        }

        public override void OnRoundEnd()
        {
            Destroy();
        }

        public override bool IsImmortal()
        {
            return true;
        }

        public override bool IsInvincibleHp(BattleUnitModel attacker)
        {
            return true;
        }
    }
}