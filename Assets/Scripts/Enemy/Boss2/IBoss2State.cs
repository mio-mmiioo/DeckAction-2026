using UnityEngine;

public interface IBoss2State
{
    // クラスの状態を取得する
    BOSS_2_STATE state { get; }

    // 状態開始時、実行される
    void Entry();

    void Update();

    // 状態終了時呼び出される
    void Exit();
}

/// <summary>
/// ボス2の状態
/// </summary>
public enum BOSS_2_STATE
{
    B_2_STATE_MOVE,
    B_2_STATE_ATTACK_1,
    MAX_B_2_STATE
}
