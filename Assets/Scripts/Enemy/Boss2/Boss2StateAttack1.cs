using UnityEngine;
using UnityEngine.InputSystem;

public class Boss2StateAttack1 : IBoss2State
{
    private Boss2 boss2;
    public BOSS_2_STATE state => BOSS_2_STATE.B_2_STATE_ATTACK_1;

    private GameObject boss2Attack;
    private Boss2Float boss2Float;

    /// <summary>
    /// 敵を設定
    /// </summary>
    /// <param name="e">Boss2</param>
    public Boss2StateAttack1(Boss2 e)
    {
        boss2 = e;
        boss2Attack = GameObject.Find("Boss2Attack");
        boss2Float = boss2.GetComponent<Boss2Float>();
    }

    public void Entry()
    {
        boss2Attack.GetComponent<SwordManager>().CreateSword();
        boss2Float.Init(boss2.transform.position);
    }

    public void Update()
    {
        boss2.transform.position = boss2Float.GetMovePosition();
        if (boss2Attack.GetComponent<SwordManager>().GetSwords() <= 0)
        {
            boss2.Move();
        }
    }

    public void Exit()
    {
    }
}
