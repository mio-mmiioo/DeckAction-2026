using UnityEngine;

public class SetMagicAttackPosition : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offsetX = 0.2f;

    private Transform createPosition; // 位置
    // 方向

    void Start()
    {
        Transform t = player.transform;
        if (t.localScale.x > 0.0f)
        {
            t.position += new Vector3(offsetX, 0.0f, 0.0f);
        }
        else
        {
            t.position -= new Vector3(offsetX, 0.0f, 0.0f);
        }

        createPosition = t;

    }


    /// <summary>
    /// 魔法攻撃の生成位置を取得
    /// </summary>
    /// <returns>生成位置</returns>
    public Transform GetCreatePosition()
    {
        return createPosition;
    }
}
