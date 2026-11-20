using UnityEngine;

/// <summary>
/// キャラクターのターン切り替えに使用
/// </summary>
public class CharaSetAttackTurn : MonoBehaviour
{
    public bool isAttackTurn; // 攻撃ターンならtrue

    /// <summary>
    /// 攻撃ターンかセットする
    /// </summary>
    /// <param name="flag">trueなら攻撃ターン</param>
    public void SetIsAttackTurn(bool flag)
    {
        isAttackTurn = flag;
    }

    /// <summary>
    /// 攻撃ターンか取得する
    /// </summary>
    /// <returns>攻撃ターンならtrue</returns>
    public bool GetIsAttackTurn()
    {
        return isAttackTurn;
    }
}
