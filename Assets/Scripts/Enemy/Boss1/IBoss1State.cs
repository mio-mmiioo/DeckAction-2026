using UnityEngine;

public interface IBoss1State
{

    BOSS_1_STATE state { get; }

    void Entry();

    void Update();

    void Exit();
}

/// <summary>
/// ボス１の状態
/// </summary>
public enum BOSS_1_STATE
{
    B_1_STATE_JUMP,
    B_1_STATE_IDLE,

}
