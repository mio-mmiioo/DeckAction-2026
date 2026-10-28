using UnityEngine;

public interface IEnemyAState
{
    // クラスの状態を取得する
    ENEMY_A_STATE state { get; }

    // 状態開始時、実行される
    void Entry();

    void Update();

    // 状態終了時呼び出される
    void Exit();
}


/// <summary>
/// 敵Aの状態
/// </summary>
public enum ENEMY_A_STATE
{
    E_A_STATE_IDLE,
    E_A_STATE_WALK,
    MAX_E_A_STATE
}
