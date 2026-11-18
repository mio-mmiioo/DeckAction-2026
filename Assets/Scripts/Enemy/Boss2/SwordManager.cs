using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    [Tooltip("剣のプレハブを設定してください")]
    [SerializeField] private GameObject swordPrefab;

    [Tooltip("プレイヤーのトランスフォームを設定してください")]
    [SerializeField] private Transform player;

    [SerializeField] private float angleRange = 120.0f;

    private const int MAX_SWORD_NUMBER = 7; // 剣の本数
    private const float WAIT_TIME = 2.0f; // 剣を配置してから飛ばすまでの時間
    private const float LAUNCH_INTERVAL = 0.8f; // 剣を飛ばしてから次の剣を飛ばすまでの時間
    private List<GameObject> swords = new List<GameObject>(); // 剣を管理する

    void Start()
    {

    }

    void Update()
    {

    }

    public void CreateSword()
    {
        // 剣を生成する処理
        StartCoroutine(SwordAttackCoroutine());
    }

    private IEnumerator SwordAttackCoroutine()
    {
        for (int count = 0; count < MAX_SWORD_NUMBER; count++)
        {
            float angle = -angleRange / 2.0f + angleRange / (MAX_SWORD_NUMBER - 1) * count + 90.0f;
            float rad = angle * Mathf.Deg2Rad;

            Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * 3.0f;
            Vector2 spawnPosition = (Vector2)player.position + Vector2.up * 2.0f + offset;

            GameObject sword = Instantiate(swordPrefab, spawnPosition, Quaternion.identity);
            swords.Add(sword);
        }

        yield return new WaitForSeconds(WAIT_TIME);

        // 生成した剣をランダムに発射
        while(swords.Count > 0)
        {
            int randomIndex = Random.Range(0, swords.Count);
            GameObject selectedSword = swords[randomIndex];
            swords.RemoveAt(randomIndex);
            if (selectedSword != null)
            {
                Sword s = selectedSword.GetComponent<Sword>();
                s.LaunchSword(player.position);
            }
            yield return new WaitForSeconds(LAUNCH_INTERVAL);
        }
    }

    public int GetSwords()
    {
        return swords.Count;
    }

    //public void LaunchSword()
    //{
    //    swordPrefab.GetComponent<Sword>().LaunchSword(player.position);
    //}
}
