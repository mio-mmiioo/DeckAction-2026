using UnityEngine;
using UnityEngine.InputSystem;

public class Boss2StateAttack1 : IBoss2State
{
    private Boss2 boss2;
    public BOSS_2_STATE state => BOSS_2_STATE.B_2_STATE_ATTACK_1;

    private GameObject boss2Attack1;

    /// <summary>
    /// 敵を設定
    /// </summary>
    /// <param name="e">Boss2</param>
    public Boss2StateAttack1(Boss2 e)
    {
        boss2 = e;
        boss2Attack1 = GameObject.Find("Boss2Attack1");
    }

    public void Entry()
    {
        Debug.Log("ボス2が剣を飛ばした");
        boss2Attack1.GetComponent<CreateSword>().LaunchSword();
    }

    public void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            boss2.Move();
        }
    }

    public void Exit()
    {
    }
}
