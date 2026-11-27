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

    [SerializeField] private CharaHp playerHp;

    // ターン関連
    private TurnManager turnManager;
    private TurnManager.TURN_TYPE prevTurn;

    // 敵の生成関連
    private GameObject waveBoss;
    private bool isStartWave; // ウェーブが開始されているならtrue
    private bool isCreateBoss; // ボスを生成したならtrue

    void Start()
    {
        isStartWave = false;
        isCreateBoss = false;
        turnManager = GetComponent<TurnManager>();
    }

    void Update()
    {
        // ウェーブが開始されていないなら次の処理はしない
        if (isStartWave == false)
        {
            return;
        }

        // 雑魚敵がいない場合
        if (character.transform.childCount == 1 && isCreateBoss == false)
        {
            Debug.Log("ボスの生成");
            waveBoss = waveManager.CreateWave2Boss();
            isCreateBoss = true;
        }

        turnManager.TurnUpdate(); // ターンの更新処理

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
        if (playerHp.GetHP() <= 0)
        {
            ret = true;
        }

        return ret;
    }

    public bool GetIsGameClear()
    {
        bool ret = false;
        if (waveBoss != null)
        {
            if (waveBoss.GetComponent<CharaHp>().GetHP() <= 0)
            {
                ret = true;
            }
        }
        return ret;
    }

    /// <summary>
    /// waveを開始していいかセットする
    /// </summary>
    /// <param name="flag"></param>
    public void SetIsStartWave(bool flag)
    {
        isStartWave = flag;

        if (isStartWave == true)
        {
            Debug.Log("ウェーブ開始");
            waveManager.CreateWave2();
            SetTurn();
        }

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
