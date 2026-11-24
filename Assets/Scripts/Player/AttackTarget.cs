using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの攻撃先を決定するスクリプト
/// </summary>
public class AttackTarget : MonoBehaviour
{
    private Transform targetEnemy;//攻撃する敵

    private CharaHp targetHp;//敵のHP

    private Image targetImage;//画像

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    /// <summary>
    /// ターゲットをセットする
    /// セットされたターゲットの照準画像をオンにし、攻撃対象とする
    /// </summary>
    /// <param name="enemy"></param>
    public void SetTarget(Transform enemy)
    {
        if(targetEnemy)
        targetImage.enabled = false;

        targetEnemy = enemy;

        if (targetEnemy)
        {
            Image[] images = targetEnemy.GetComponentsInChildren<Image>(true);

            targetHp = targetEnemy.GetComponent<CharaHp>();

            targetImage = images.FirstOrDefault(img => img.gameObject.name == "Target");

            targetImage.enabled = true;
        }
        
    }

    /// <summary>
    /// 攻撃先を返す
    /// </summary>
    /// <returns></returns>
    public CharaHp GetTargetHP()
    {
        return targetHp;
    }
}
