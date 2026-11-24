using UnityEngine;

public class Boss2StateAttack3 : IBoss2State
{
    private Boss2 boss2;
    public BOSS_2_STATE state => BOSS_2_STATE.B_2_STATE_ATTACK_3;

    private GameObject boss2Attack3;

    /// <summary>
    /// 敵を設定
    /// </summary>
    /// <param name="e">Boss2</param>
    public Boss2StateAttack3(Boss2 e)
    {
        boss2 = e;
        boss2Attack3 = GameObject.Find("Boss2Attack3");
    }

    public void Entry()
    {
        boss2Attack3.GetComponent<IceManager>().CreateIce();
    }

    public void Update()
    {
        if (boss2Attack3.GetComponent<IceManager>().GetIsAttaking() == false)
        {
            boss2.Move();
        }
    }

    public void Exit()
    {
    }
}
