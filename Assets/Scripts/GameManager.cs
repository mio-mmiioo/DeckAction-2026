using UnityEngine;

/// <summary>
/// ゲーム全体を管理する
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject character; // 画面上のキャラの親オブジェクト
    private TurnManager turnManager;
    private TurnManager.TURN_TYPE prevTurn;

    void Start()
    {
        turnManager = GetComponent<TurnManager>();

        SetTurn(); // 現在のターンを各キャラに伝える
    }

    void Update()
    {
        // ターンが切り替わった瞬間
        if (prevTurn != turnManager.GetCurrentTurn())
        {
            Debug.Log("GameManagerがターン変更を検知");
            SetTurn();
        }
        prevTurn = turnManager.GetCurrentTurn();
    }

    public bool GetIsGameOver()
    {
        bool ret = false;

        // プレイヤーの体力が0など

        return ret;
    }

    public bool GetIsGameClear()
    {
        bool ret = false;

        // 敵の数を把握する処理など

        return ret;
    }

    /// <summary>
    /// ターンをキャラクターにセットする
    /// </summary>
    private void SetTurn()
    {
        CharaSetAttackTurn[] characters = GetComponentsInChildren<CharaSetAttackTurn>();
        Debug.Log("取得したキャラクター数" + characters.Length);

        Debug.Log("現在のターン:" + turnManager.GetCurrentTurn());

        // エネミーターン
        if (turnManager.GetCurrentTurn() == TurnManager.TURN_TYPE.ENEMY_TURN)
        {
            Debug.Log("currentTypeにエネミーは入っている");
            foreach (CharaSetAttackTurn chara in characters)
            {
                Debug.Log("名前" + chara.name);
                Debug.Log("タグ" + chara.tag);
                if (chara.CompareTag("Enemy"))
                {
                    chara.SetIsAttackTurn(true); // 敵は攻撃ターンtrue
                }
                else if (chara.CompareTag("Player"))
                {
                    chara.SetIsAttackTurn(false); // プレイヤーは攻撃ターンfalse
                }
            }
        }
        // プレイヤーターン
        if (turnManager.GetCurrentTurn() == TurnManager.TURN_TYPE.PLAYER_TURN)
        {
            // プレイヤーに攻撃できるよって伝える
            foreach (CharaSetAttackTurn chara in characters)
            {
                if (chara.CompareTag("Enemy"))
                {
                    chara.SetIsAttackTurn(false); // 敵は攻撃ターンfalse
                }
                else if (chara.CompareTag("Player"))
                {
                    chara.SetIsAttackTurn(true); // プレイヤーは攻撃ターンtrue
                }
            }
        }
    }
}
