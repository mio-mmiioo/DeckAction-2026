using UnityEngine;

public interface IEnemyBState
{
    ENEMY_B_STATE state { get; }

    void Entry();

    void Update();

    void Exit();
}

/// <summary>
/// 敵Bの状態
/// </summary>
public enum ENEMY_B_STATE
{
    E_B_STATE_MOVE,
    MAX_E_B_STATE
}