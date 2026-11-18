using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// カードの能力の親クラス。カードの能力を継承して作る際に使用する
/// </summary>
public abstract class CardAbility : ScriptableObject
{
    [Header("表示する効果説明")]public string explation;

    [Header("効果の数字")] public int value;
    public abstract void Execute(PlayerUseCard user, CardManager cardManager);

}
