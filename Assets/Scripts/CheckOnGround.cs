using UnityEngine;

public class CheckOnGround : MonoBehaviour
{
    [Tooltip("地面として認識するレイヤー GroundLayerを設定してください")]
    [SerializeField] private LayerMask groundLayer;
    
    [Tooltip("レイの長さ 足元から少し出るくらいに設定してください")]
    [SerializeField] private float rayLength = 1.0f;

    [Tooltip("transform 確認したいオブジェクトのtransformを設定してください")]
    [SerializeField] private Transform t;

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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(t.position, t.position + Vector3.down * rayLength);
    }
}
