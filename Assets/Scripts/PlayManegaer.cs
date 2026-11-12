using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManegaer : MonoBehaviour
{
    [Tooltip("プレイヤーのゲームオブジェクトを設定してください")]
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (player.GetComponent<CharaHp>().GetHP() <= 0)
        {
            Invoke("PlayerDied", 1.0f);
        }

        if(transform.childCount == 0)
        {
            Invoke("EnemyDied", 1.0f);
        }


    }


    /// <summary>
    /// 敵が全滅した場合
    /// </summary>
    private void EnemyDied()
    {
        SceneManager.LoadScene("ClearScene");
    }

    /// <summary>
    /// プレイヤーが死んだ場合
    /// </summary>
    private void PlayerDied()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
