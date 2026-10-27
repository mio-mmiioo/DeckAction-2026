using UnityEngine;

public class CheckOnGround : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer; // 地面として認識するレイヤー
    [SerializeField] private float rayLength = 1.0f; // レイの長さ
    [SerializeField] private Transform t; // 確認したいオブジェクトのtransform

    [HideInInspector] public bool onGround = false; // 地面に足がついているならtrue

    private void FixedUpdate()
    {
        CheckGround();
    }

    /// <summary>
    /// レイキャストで地面との当たり判定を行う
    /// </summary>
    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(t.position, Vector2.down, rayLength, groundLayer);
        if (hit)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    /// <summary>
    /// レイキャストの線を表示
    /// </summary>
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(t.position, t.position + Vector3.down * rayLength);
    //}
}
