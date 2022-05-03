using KamiyoStaticUtil.Utils;

namespace Mary_Ib21341.Dice
{
    public class DiceCardAbility_LostHopeDice_21341 : DiceCardAbilityBase
    {
        public override void OnWinParrying()
        {
            if (UnitUtil.SupportCharCheck(owner) != 1) return;
            if (card?.target?.currentDiceAction?.cardBehaviorQueue.Count > 0)
                card?.target?.currentDiceAction?.DestroyDice(DiceMatch.AllDice, DiceUITiming.AttackAfter);
        }
    }
}