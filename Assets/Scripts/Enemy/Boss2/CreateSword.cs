using UnityEngine;

public class CreateSword : MonoBehaviour
{
    [Tooltip("剣のプレハブを設定してください")]
    [SerializeField] private GameObject swordPrefab;

    [Tooltip("プレイヤーのトランスフォームを設定してください")]
    [SerializeField] private Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //public void CreateSword(int swords)
    //{
    //    // 剣を生成する処理
    //}

    public void LaunchSword()
    {
        swordPrefab.GetComponent<Sword>().LaunchSword(player.position);
    }
}
