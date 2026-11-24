using Unity.Mathematics;
using UnityEngine;

public class EnemyBStateMove : IEnemyBState
{
    private EnemyB enemyB;
    public ENEMY_B_STATE state => ENEMY_B_STATE.E_B_STATE_MOVE;

    private float FLOAT_HEIGHT = 0.2f; // 浮く高さ
    private float FLOAT_WIDTH = 0.1f; // 浮く横幅
    private float MOVE_SPEED = 0.8f; // 移動速度
    private float HORIZONTAL_SPEED_FACTOR = 0.4f;
    private Vector3 startPosition; // 初期位置

    private CharaSetAttackTurn attackTurn; // ターン管理

    public EnemyBStateMove(EnemyB e)
    {
        enemyB = e;
        attackTurn = e.GetComponent<CharaSetAttackTurn>();
    }

    public void Entry()
    {
        startPosition = enemyB.transform.position;
    }

    public void Update()
    {
        // 上下の揺れ
        float y = Mathf.Sin(Time.time * MOVE_SPEED) * FLOAT_HEIGHT;
        float x = Mathf.Sin(Time.time * MOVE_SPEED * HORIZONTAL_SPEED_FACTOR) * FLOAT_WIDTH;

        enemyB.transform.position = startPosition + new Vector3(x, y, 0.0f);
    }

    public void Exit()
    {

    }
}
