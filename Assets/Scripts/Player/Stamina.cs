using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] private int maxStamina = 100; // 最大のスタミナ
    [SerializeField] private int currentStamina; // 現在のスタミナ

    void Start()
    {
        currentStamina = maxStamina;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina); // スタミナの最小と最大の値を決める
    }

    /// <summary>
    /// スタミナを消費する処理
    /// </summary>
    /// <param name="stamina">消費するスタミナ( a > 0 )</param>
    public void UseStamina(int stamina)
    {
        if (stamina <= 0)
        {
            return;
        }
        currentStamina -= stamina;
    }

    /// <summary>
    /// スタミナを加算する
    /// </summary>
    /// <param name="stamina">加算するスタミナ</param>
    public void AddStamina(int stamina)
    {
        currentStamina += stamina;
    }
}
