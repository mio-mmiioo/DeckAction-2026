using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ジャンプ時に落下し始めた瞬間を確認する
/// </summary>
public class EnemyCheckFall : MonoBehaviour
{
    public bool isFalling = false; // trueなら落下している
    public bool prevIsFalling = false;
    [Tooltip("落下を確認したいオブジェクトのtransformを設定してください")]
    [SerializeField] private Transform charaTransform;
    float currentPositionY; // 現在のy座標
    float prevPositionY; // 前回のy座標

    void Start()
    {
        currentPositionY = charaTransform.position.y;
        prevPositionY = currentPositionY;
    }

    void Update()
    {
        currentPositionY = charaTransform.position.y;
        isFalling = false;
        if (prevPositionY > currentPositionY)
        {
            isFalling = true;
        }

        prevIsFalling = isFalling;
        prevPositionY = currentPositionY;
    }


    /// <summary>
    /// 落下しているかを確認する
    /// </summary>
    /// <returns>trueなら落下している</returns>
    public bool GetIsStartFall()
    {
        bool ret = false;
        if (isFalling == true && prevIsFalling == false)
        {
            ret = true;
        }

        return ret;
    }
}
