using UnityEngine;
using UnityEngine.InputSystem;

public class Boss2StateMove : IBoss2State
{
    private Boss2 boss2;
    public BOSS_2_STATE state => BOSS_2_STATE.B_2_STATE_MOVE;

    private float FLOAT_HEIGHT = 0.3f; // 浮く高さ
    private float FLOAT_WIDTH = 0.2f; // 浮く横幅
    private float MOVE_SPEED = 1.5f; // 移動速度
    private float HORIZONTAL_SPEED_FACTOR = 0.7f;
    private Vector3 startPosition; // 初期位置

    private CharaSetAttackTurn attackTurn; // ターン管理

    /// <summary>
    /// 敵を設定
    /// </summary>
    /// <param name="e">Boss2</param>
    public Boss2StateMove(Boss2 e)
    {
        boss2 = e;
        attackTurn = e.GetComponent<CharaSetAttackTurn>();
    }

    public void Entry()
    {
        startPosition = boss2.transform.position;
    }

    public void Update()
    {
        // 上下の揺れ
        float y = Mathf.Sin(Time.time * MOVE_SPEED) * FLOAT_HEIGHT;
        float x = Mathf.Sin(Time.time * MOVE_SPEED * HORIZONTAL_SPEED_FACTOR) * FLOAT_WIDTH;

        boss2.transform.position = startPosition + new Vector3(x, y, 0.0f);

        if (attackTurn.GetIsAttackTurn() == true)
        {
            if (Keyboard.current.nKey.wasPressedThisFrame)
            {
                boss2.Attack1();
            }
            if (Keyboard.current.bKey.wasPressedThisFrame)
            {
                boss2.Attack3();
            }
        }
    }

    public void Exit()
    {
    }
}
