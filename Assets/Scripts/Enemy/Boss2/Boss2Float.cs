using Unity.Mathematics;
using UnityEngine;

public class Boss2Float : MonoBehaviour
{
    private const float FLOAT_HEIGHT = 0.3f; // 浮く高さ
    private const float FLOAT_WIDTH = 0.2f; // 浮く横幅
    private const float MOVE_SPEED = 1.5f; // 移動速度
    private const float HORIZONTAL_SPEED_FACTOR = 0.7f;
    private Vector3 startPosition; // 初期位置

    public void Init(Vector3 position)
    {
        startPosition = position;
    }

    public Vector3 GetMovePosition()
    {
        Vector3 ret;
        // 上下の揺れ
        float y = Mathf.Sin(Time.time * MOVE_SPEED) * FLOAT_HEIGHT;
        float x = Mathf.Sin(Time.time * MOVE_SPEED * HORIZONTAL_SPEED_FACTOR) * FLOAT_WIDTH;
        ret = startPosition + new Vector3(x, y, 0.0f);
        return ret;
    }

}
