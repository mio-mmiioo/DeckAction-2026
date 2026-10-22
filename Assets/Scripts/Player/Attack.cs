using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public bool isHit = false; // 攻撃範囲に攻撃対象がいるならtrue
    public bool isAttack = false; // 攻撃するならtrue

    void Start()
    {
        
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isHit == true)
        {
            isAttack = true;
        }
    }

    private void FixedUpdate()
    {
        if (isAttack == true)
        {
            isAttack = false;
            Debug.Log("攻撃が当たった");
        }
    }

    /// <summary>
    /// 攻撃範囲に敵がいるか確認する
    /// </summary>
    /// <param name="attackArea">攻撃範囲</param>
    private void OnTriggerStay2D(Collider2D attackArea)
    {
        if (attackArea.CompareTag("Enemy"))
        {
            isHit = true;
        }
    }

    /// <summary>
    /// 攻撃範囲から何かが出て行ったことを確認する
    /// </summary>
    /// <param name="attackArea"></param>
    void OnTriggerExit2D(Collider2D attackArea)
    {
        isHit = false;
    }
}
