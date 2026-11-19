using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Turn : MonoBehaviour
{
    // ターンの種類
    public enum TURN_TYPE
    {
        ENEMY_TURN,
        PLAYER_TURN,
        MAX_TURN_TYPE
    }

    private TurnDisplay turnDisplay;
    private TURN_TYPE currentTurn; // 現在のターン
    private TURN_TYPE prevTurn; // 前回のターン

    void Start()
    {
        turnDisplay = GetComponent<TurnDisplay>();
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
                turnDisplay.ShowPlayerTurn();
            }
            else if (currentTurn == TURN_TYPE.ENEMY_TURN)
            {
                Debug.Log("エネミーターン開始");
                turnDisplay.ShowEnemyTurn();
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
