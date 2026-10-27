using UnityEngine;

public class CharaAttack : MonoBehaviour
{
    [Tooltip("攻撃範囲を指定してください")]
    [SerializeField] private Collider2D attackCollider;

    [Tooltip("攻撃範囲が有効な時間を指定してください")]
    [SerializeField] private float time = 0.3f;

    void Start()
    {
        SetOffEnabled();
    }

    /// <summary>
    /// 攻撃の処理を行う
    /// </summary>
    public void Attack()
    {
        attackCollider.enabled = true; // 攻撃範囲を有効にする
        Invoke("SetOffEnabled", time); // 指定秒数後に攻撃判定をオフにする
    }

    /// <summary>
    /// 攻撃判定をオフに設定
    /// </summary>
    private void SetOffEnabled()
    {
        attackCollider.enabled = false;
    }
}
