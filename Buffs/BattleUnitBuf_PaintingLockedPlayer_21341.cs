using BigDLL4221.Buffs;

namespace Mary_Ib21341.Buffs
{
    public class BattleUnitBuf_PaintingLockedPlayer_21341 : BattleUnitBuf_LockedUnit_DLL4221
    {
        public BattleUnitBuf_PaintingLockedPlayer_21341() : base(infinite: true, lastOneScene: false)
        {
        }

        public override bool IsTargetable()
        {
            return true;
        }
    }
}