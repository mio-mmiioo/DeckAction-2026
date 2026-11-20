using UnityEngine;

[CreateAssetMenu(fileName = "Ability_4", menuName = "Abilities/Ability_4")]
public class Ability_4 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        int stamina=user.stamina.GetMaxStamina();
        stamina = stamina / 10;
        user.stamina.AddStamina(stamina);
    }
}

