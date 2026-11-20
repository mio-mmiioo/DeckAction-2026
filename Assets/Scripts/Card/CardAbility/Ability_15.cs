using UnityEngine;

[CreateAssetMenu(fileName = "Ability_15", menuName = "Abilities/Ability_15")]
public class Ability_15 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        int hp = user.charaHp.GetMaxHP();
        hp = hp / 5;
        user.charaHp.TakeDamage(hp);
        //user.charahp.ismuteki=true;
    }
}

