using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Ability_1")]
public class Ability_1 : CardAbility
{
    public void ExecuteAbility()
    {
        // Ability_1の効果をここに実装する
        Debug.Log("Ability_1が発動しました！");

        //次に使うカードのスタミナを-2する
    }
}
