using UnityEngine;

[CreateAssetMenu(fileName = "Ability_3", menuName = "Abilities/Ability_3")]
public class Ability_3 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        float hp=user.charaHp.GetMaxHP();
        hp = hp /10;
        user.charaHp.AddHP(hp);
    }
}

