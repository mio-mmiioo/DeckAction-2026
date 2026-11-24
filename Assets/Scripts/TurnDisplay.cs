using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// ターンを画面左右から中央へ移動して表示させる
/// </summary>
public class TurnDisplay : MonoBehaviour
{
    [Tooltip("TrunTextを設定してください")]
    [SerializeField] private TextMeshProUGUI turnText;

    [Tooltip("TrunTimerを設定してください")]
    [SerializeField] private TextMeshProUGUI turnTimer;

    [Tooltip("DebugTrunTextを設定してください")]
    [SerializeField] private TextMeshProUGUI debugTurnText;

    [Tooltip("文字を移動させている時間")]
    [SerializeField] private float MoveTime = 0.8f;

    [Tooltip("文字を中央に表示させている時間")]
    [SerializeField] private float StayTime = 0.8f;

    private const int START_X = 1500; // 文字の移動開始位置のx座標

    private Coroutine currentDisplay; // 現在表示しているもの

    /// <summary>
    /// プレイヤーターンと表示をする
    /// </summary>
    public void ShowPlayerTurn(string turnMessage)
    {
        StartTurn(turnMessage, true);
    }

    /// <summary>
    /// エネミーターンと表示する
    /// </summary>
    public void ShowEnemyTurn(string turnMessage)
    {
        StartTurn(turnMessage, false);
    }

    /// <summary>
    /// ターンのメッセージを表示する
    /// </summary>
    /// <param name="turnMessage">表示したいメッセージ</param>
    /// <param name="isFromLeft">左から右へ移動させるならtrue</param>
    private void StartTurn(string turnMessage, bool isFromLeft)
    {
        if (currentDisplay != null)
        {
            StopCoroutine(currentDisplay);
        }
        currentDisplay = StartCoroutine(AnimateTurn(turnMessage, isFromLeft));
    }

    private IEnumerator AnimateTurn(string turnMessage, bool isFromLeft)
    {
        RectTransform rect = turnText.rectTransform;
        turnText.gameObject.SetActive(true);
        turnText.text = turnMessage;

        // 画面外の開始位置と終了位置
        Vector2 center = Vector2.zero;
        Vector2 start;
        if (isFromLeft == true)
        {
            start = new Vector2(-START_X, 0);
        }
        else
        {
            start = new Vector2(START_X, 0);
        }

        rect.anchoredPosition = start;

        float timer = 0.0f;

        while (timer < MoveTime)
        {
            timer += Time.deltaTime;

            float t = Mathf.Clamp01(timer / MoveTime);
            t = Mathf.SmoothStep(0.0f, 1.0f, t);

            rect.anchoredPosition = Vector2.Lerp(start, center, t);

            yield return null;
        }

        rect.anchoredPosition = center;

        // 中央で停止
        yield return new WaitForSeconds(StayTime);

        turnText.gameObject.SetActive(false);
    }

    /// <summary>
    /// タイマーを表示する
    /// </summary>
    /// <param name="timer">時間</param>
    public void SetTurnTimer(float timer)
    {
        string str = timer.ToString("F0"); // 小数点以下を無視して表示
        turnTimer.text = str;
    }


    /// <summary>
    /// デバッグ用、ターンを表示し続ける
    /// </summary>
    /// <param name="turnMessage">表示したいメッセージ</param>
    public void SetTurnText(string turnMessage)
    {
        debugTurnText.text = turnMessage;
    }
}
