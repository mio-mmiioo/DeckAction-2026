using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Tooltip("エネミーターン時に上昇させる高さを設定してください")]
    [SerializeField] private float enemyTurnHeight = 3.0f;

    [Tooltip("カメラの移動速度を設定してください")]
    [SerializeField] private float moveSpeed = 2.0f;

    [SerializeField] private CharaSetAttackTurn playerAttackTurn;

    private Vector3 defaultPosition; // カメラの初期位置
    private Vector3 targetPosition; // 移動先の位置


    void Start()
    {
        defaultPosition = transform.position;
        targetPosition = defaultPosition;
    }

    void Update()
    {
        // 各ターンに合わせて目的地を設定
        if (playerAttackTurn.GetIsAttackTurn() == true)
        {
            targetPosition = defaultPosition;
        }
        else
        {
            targetPosition = defaultPosition + new Vector3(0.0f, enemyTurnHeight, 0);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// エネミーターン時のカメラに設定する
    /// </summary>
    public void SetEnemyTurnCamera()
    {

    }

    /// <summary>
    /// プレイヤーターン時のカメラに設定する
    /// </summary>
    public void SetPlayerTurnCamera()
    {

    }
}
