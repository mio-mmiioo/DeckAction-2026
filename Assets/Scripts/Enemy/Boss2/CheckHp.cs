using UnityEngine;

public class CheckHp : MonoBehaviour
{
    private CharaHp charaHp;
    private Rigidbody2D rb;

    void Start()
    {
        charaHp = GetComponent<CharaHp>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 体力が減っていた場合
        if (charaHp.GetHP() < charaHp.GetPrevHP())
        {
            rb.linearVelocity = new Vector2(0.0f, rb.linearVelocity.y);
        }
    }
}
