namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_ArtWorld_21341 : PassiveAbilityBase
    {
        private readonly StageLibraryFloorModel
            _floor = Singleton<StageController>.Instance.GetCurrentStageFloorModel();

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (_floor.Sephirah == SephirahType.Netzach)
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    min = 1,
                    max = 1
                });
        }
    }
}