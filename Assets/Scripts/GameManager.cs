using UnityEngine;

/// <summary>
/// ゲーム全体を管理する
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject character; // 画面上のキャラの親オブジェクト

    private void Update()
    {
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
}
