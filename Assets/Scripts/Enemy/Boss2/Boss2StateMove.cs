using UnityEngine;
using UnityEngine.InputSystem;

public class Boss2StateMove : IBoss2State
{
    private Boss2 boss2;
    public BOSS_2_STATE state => BOSS_2_STATE.B_2_STATE_MOVE;


    private Boss2Float boss2Float;
    private CharaSetAttackTurn attackTurn; // ターン管理

    private const float ATTACK_INTERVAL_TIME = 2.0f;
    private float attackIntervalTimer;

    /// <summary>
    /// 敵を設定
    /// </summary>
    /// <param name="e">Boss2</param>
    public Boss2StateMove(Boss2 e)
    {
        boss2 = e;
        attackTurn = e.GetComponent<CharaSetAttackTurn>();
        boss2Float = e.GetComponent<Boss2Float>();
    }

    public void Entry()
    {
        boss2Float.Init(boss2.transform.position);
        attackIntervalTimer = ATTACK_INTERVAL_TIME;
    }

    public void Update()
    {
        boss2.transform.position = boss2Float.GetMovePosition();
        
        if (attackTurn.GetIsAttackTurn() == true)
        {
            attackIntervalTimer -= Time.deltaTime;
            if (attackIntervalTimer <= 0.0f)
            {
                Debug.Log("ボス2が攻撃を選択");
                int randomNumber = Random.Range(0, 2);
                if (randomNumber == 0)
                {
                    Debug.Log("ボス2が攻撃1を開始");
                    boss2.Attack1();
                }
                if (randomNumber == 1)
                {
                    boss2.Attack3();
                    Debug.Log("ボス2が攻撃3を開始");
                }
            }

            if (Keyboard.current.nKey.wasPressedThisFrame)
            {
                boss2.Attack1();
            }
            if (Keyboard.current.bKey.wasPressedThisFrame)
            {
                boss2.Attack3();
            }
            //if (Keyboard.current.mKey.wasPressedThisFrame)
            //{
            //    boss2.Attack4();
            //}
        }
    }

    public void Exit()
    {
    }
}
