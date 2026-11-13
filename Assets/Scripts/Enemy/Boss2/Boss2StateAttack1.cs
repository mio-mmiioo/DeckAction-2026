using UnityEngine;

public class Boss2StateAttack1 : IBoss2State
{
    private Boss2 boss2;
    public BOSS_2_STATE state => BOSS_2_STATE.B_2_STATE_MOVE;

    /// <summary>
    /// 敵を設定
    /// </summary>
    /// <param name="e">Boss2</param>
    public Boss2StateAttack1(Boss2 e)
    {
        boss2 = e;
    }

    public void Entry()
    {
        Debug.Log("ボス2攻撃処理1の開始");
    }

    public void Update()
    {
    }

    public void Exit()
    {
    }
}
