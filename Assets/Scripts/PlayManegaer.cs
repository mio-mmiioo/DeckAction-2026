using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayManegaer : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        // とりあえずキー入力、後でタイマーをセットする
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            gameManager.SetIsStartWave(true);
        }

        if (gameManager.GetIsGameClear() == true)
        {
            Invoke("EnemyDied", 1.0f);
        }

        if (gameManager.GetIsGameOver() == true)
        {
            Invoke("PlayerDied", 1.0f);
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
