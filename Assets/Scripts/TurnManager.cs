using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    // ターンの種類
    public enum TURN_TYPE
    {
        ENEMY_TURN,
        PLAYER_TURN,
        MAX_TURN_TYPE
    }

    private TurnDisplay turnDisplay;
    private DebugTurnDisplay debugTurnDisplay;
    private TURN_TYPE currentTurn; // 現在のターン
    private TURN_TYPE prevTurn; // 前回のターン

    private const string PLAYER_TURN_MESSAGE = "PLAYER TURN"; // プレイヤーターン時に表示するメッセージ
    private const string ENEMY_TURN_MESSAGE = "ENEMY TURN"; // エネミーターン時に表示するメッセージ

    void Start()
    {
        turnDisplay = GetComponent<TurnDisplay>();
        debugTurnDisplay = GetComponent<DebugTurnDisplay>();

        // 最初はプレイヤーターンに設定する
        currentTurn = TURN_TYPE.PLAYER_TURN;
        debugTurnDisplay.SetTurnText(PLAYER_TURN_MESSAGE);
        turnDisplay.ShowPlayerTurn(PLAYER_TURN_MESSAGE);

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
        if (IsChangeTurn() == true)
        {
            if (currentTurn == TURN_TYPE.PLAYER_TURN)
            {
                Debug.Log("プレイヤーターン開始");
                debugTurnDisplay.SetTurnText(PLAYER_TURN_MESSAGE);
                turnDisplay.ShowPlayerTurn(PLAYER_TURN_MESSAGE);
            }
            else if (currentTurn == TURN_TYPE.ENEMY_TURN)
            {
                Debug.Log("エネミーターン開始");
                debugTurnDisplay.SetTurnText(ENEMY_TURN_MESSAGE);
                turnDisplay.ShowEnemyTurn(ENEMY_TURN_MESSAGE);
            }
        }

        prevTurn = currentTurn;
    }

    /// <summary>
    /// 現在のターンを取得する
    /// </summary>
    /// <returns>現在のターン</returns>
    public TURN_TYPE GetCurrentTurn()
    {
        return currentTurn;
    }

    /// <summary>
    /// プレイヤーターンにセットする( エネミーターン終了 )
    /// </summary>
    public void SetPlayerTurn()
    {
        currentTurn = TURN_TYPE.PLAYER_TURN;
    }

    /// <summary>
    /// エネミーターンにセットする( プレイヤーターン終了 )
    /// </summary>
    public void SetEnemyTurn()
    {
        currentTurn = TURN_TYPE.ENEMY_TURN;
    }

    /// <summary>
    /// ターンが切り替わった瞬間を返す
    /// </summary>
    /// <returns>切り替わった瞬間ならtrue</returns>
    public bool IsChangeTurn()
    {
        bool ret = false;
        if (currentTurn != prevTurn)
        {
            ret = true;
        }
        return ret;
    }
}
