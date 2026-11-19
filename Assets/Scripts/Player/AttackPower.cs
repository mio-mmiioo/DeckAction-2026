using UnityEngine;

public class AttackPower : MonoBehaviour
{
    private int attackPower = 0;

    /// <summary>
    /// 攻撃力をセットする
    /// </summary>
    /// <param name="power">攻撃力</param>
    public void SetAttackPower(int power)
    {
        attackPower = power;
    }

    /// <summary>
    /// 攻撃力を取得する
    /// </summary>
    /// <returns>攻撃力</returns>
    public int GetAttackPower()
    {
        return attackPower;
    }
}
