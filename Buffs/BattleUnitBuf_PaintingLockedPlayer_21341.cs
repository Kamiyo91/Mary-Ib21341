namespace Mary_Ib21341.Buffs
{
    public class BattleUnitBuf_PaintingLockedPlayer_21341 : BattleUnitBuf
    {
        private int _breakedDice;
        protected override string keywordId => "MaryPaintingPlayer_21341";

        public override bool IsTargetable()
        {
            return true;
        }

        public override void OnRollSpeedDice()
        {
            _breakedDice = _owner.view.speedDiceSetterUI.SpeedDicesCount;
            for (var i = 0; i < _breakedDice; i++)
            {
                _owner.speedDiceResult[i].value = 0;
                _owner.speedDiceResult[i].breaked = true;
                _owner.view.speedDiceSetterUI.GetSpeedDiceByIndex(i).BreakDice(true, true);
            }
        }

        public override int SpeedDiceBreakedAdder()
        {
            return _breakedDice;
        }

        public override void OnRoundStart()
        {
            _owner.turnState = BattleUnitTurnState.BREAK;
        }
    }
}