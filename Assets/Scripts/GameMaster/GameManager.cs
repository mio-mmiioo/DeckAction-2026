using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ゲーム全体を管理する
/// </summary>
public class GameManager : MonoBehaviour
{
    [Tooltip("Characterオブジェクトを設定してください")]
    [SerializeField] private GameObject character; // 画面上のキャラの親オブジェクト

    [Tooltip("WaveManagerを設定してください")]
    [SerializeField] private WaveManager waveManager;

    private TurnManager turnManager;
    private TurnManager.TURN_TYPE prevTurn;

    private GameObject waveBoss;
    public int enemyNum; // 敵の数
    public bool isStartWave; // ウェーブが開始されているならtrue

    void Start()
    {
        enemyNum = 0;
        isStartWave = false;
        turnManager = GetComponent<TurnManager>();
    }

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            isStartWave = true;
            waveManager.CreateWave2();
            SetTurn();
        }

        // 雑魚敵がいない場合
        if (character.transform.childCount == 1 && isStartWave == true)
        {
            Debug.Log("ボスの生成");
            waveBoss = waveManager.CreateWave2Boss();
        }

        // ターンが切り替わった瞬間
        if (prevTurn != turnManager.GetCurrentTurn())
        {
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
        if (waveBoss.GetComponent<CharaHp>().GetHP() <= 0)
        {
            ret = true;
        }
        return ret;
    }

    /// <summary>
    /// ターンをキャラクターにセットする
    /// </summary>
    private void SetTurn()
    {
        CharaSetAttackTurn[] characters = GetComponentsInChildren<CharaSetAttackTurn>();
        // エネミーターン
        if (turnManager.GetCurrentTurn() == TurnManager.TURN_TYPE.ENEMY_TURN)
        {
            foreach (CharaSetAttackTurn chara in characters)
            {
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
