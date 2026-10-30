using UnityEngine;

public class CheckDistancePlayer : MonoBehaviour
{
    [Tooltip("敵がプレイヤーを攻撃できる範囲を設定してください")]
    [SerializeField] private float distance = 3.0f;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// 攻撃パターンに遷移するときの判断をする
    /// </summary>
    /// <returns>trueならプレイヤーが遷移条件の枠内にいる</returns>
    public bool IsPlayerInAttackArea()
    {
        float d = Vector2.Distance(this.transform.position, player.transform.position);
        if (d <= distance)
        {
            return true;
        }
        return false;
    }
}
