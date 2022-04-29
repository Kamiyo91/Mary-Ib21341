using System.Linq;

namespace Mary_Ib21341.Passives
{
    public class PassiveAbility_FabricatedWorld_21341 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            BattleObjectManager.instance.GetAliveList(owner.faction).Where(x => x != owner)
                .Aggregate((x, y) => x.hp < y.hp ? x : y).RecoverHP(2);
        }
    }
}