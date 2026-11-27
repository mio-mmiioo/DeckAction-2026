using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    [Tooltip("剣のプレハブを設定してください")]
    [SerializeField] private GameObject swordPrefab;

    [SerializeField] private float angleRange = 120.0f;

    Vector3 viewportPosition; // 剣生成の中心の位置
    private const float CENTER_X = 0.5f; // 画面に対するxの割合
    private const float TOP_Y = 0.5f; // 画面に対するyの割合

    private const int MAX_SWORD_NUMBER = 7; // 剣の本数
    private const float WAIT_TIME = 2.0f; // 剣を配置してから飛ばすまでの時間
    private const float LAUNCH_INTERVAL = 0.8f; // 剣を飛ばしてから次の剣を飛ばすまでの時間
    private List<GameObject> swords = new List<GameObject>(); // 剣を管理する

    void Start()
    {
        viewportPosition = Camera.main.ViewportToWorldPoint(new Vector3(CENTER_X, TOP_Y, 0.0f));
    }

    void Update()
    {

    }

    public void CreateSword()
    {
        // 剣を生成する処理
        StartCoroutine(SwordAttack());
    }

    private IEnumerator SwordAttack()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        for (int count = 0; count < MAX_SWORD_NUMBER; count++)
        {
            float angle = -angleRange / 2.0f + angleRange / (MAX_SWORD_NUMBER - 1) * count + 90.0f;
            float rad = angle * Mathf.Deg2Rad;

            Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * 3.0f;
            Vector2 spawnPosition = (Vector2)viewportPosition + offset;
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
                s.LaunchSword(player.position); // プレイヤーのいる場所へ飛ばす
            }
            yield return new WaitForSeconds(LAUNCH_INTERVAL);
        }
    }

    public int GetSwords()
    {
        return swords.Count;
    }
}
