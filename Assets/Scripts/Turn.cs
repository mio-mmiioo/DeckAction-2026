using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Turn : MonoBehaviour
{
    public enum TURN_TYPE
    {
        ENEMY_TURN,
        PLAYER_TURN,
        MAX_TURN_TYPE
    }

    private TURN_TYPE currentTurn;
    private TURN_TYPE prevTurn;

    void Start()
    {
        currentTurn = TURN_TYPE.PLAYER_TURN;
        prevTurn = currentTurn;
    }

    void Update()
    {
        // 現在のターンをセット
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            currentTurn = TURN_TYPE.PLAYER_TURN;
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            currentTurn = TURN_TYPE.ENEMY_TURN;
        }

        // ターンが切り替わった演出
        if (currentTurn != prevTurn)
        {
            if (currentTurn == TURN_TYPE.PLAYER_TURN)
            {
                Debug.Log("プレイヤーターン開始");
            }
            else if (currentTurn == TURN_TYPE.ENEMY_TURN)
            {
                Debug.Log("エネミーターン開始");
            }
        }

        prevTurn = currentTurn;
    }

    public TURN_TYPE GetCurrentTurn()
    {
        return currentTurn;
    }

    /// <summary>
    /// プレイヤーターンにセットする( エネミーターン終了 )
    /// </summary>
    public void SetPlayerTurn()
    {
        currentTurn = Turn.TURN_TYPE.PLAYER_TURN;
    }
}
