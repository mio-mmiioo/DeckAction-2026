using System.Security.Cryptography;
using UnityEngine;

public interface IPlayerState
{
    public PLAYER_STATE state { get; }

    /// <summary>
    /// 状態開始時、最初に呼び出される
    /// </summary>
    void Entry();

    void Update();

    /// <summary>
    /// 状態終了時、呼び出される
    /// </summary>
    void Exit();
}

/// <summary>
/// プレイヤーの状態
/// </summary>
public enum PLAYER_STATE
{
    P_STATE_IDLE,
    P_STATE_WALK,
    MAX_P_STATE
}
