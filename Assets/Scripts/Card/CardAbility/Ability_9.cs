using UnityEngine;

[CreateAssetMenu(fileName = "Ability_9", menuName = "Abilities/Ability_9")]
public class Ability_9 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        if(user.currentCombo == 4)
        {
            int hp = user.charaHp.GetMaxHP();
            hp = hp / 5;
            user.charaHp.AddHP(hp);
        }
    }
}

