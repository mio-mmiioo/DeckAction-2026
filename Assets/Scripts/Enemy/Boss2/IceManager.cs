using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceManager : MonoBehaviour
{
    [Tooltip("IceのPrefabを設定してください")]
    [SerializeField] private GameObject icePrefab;

    [Tooltip("生成できるマス目の数")]
    [SerializeField] private int tileCount = 20;

    [Tooltip("タイル1枚のサイズ")]
    [SerializeField] private float tileSize = 1.0f;

    [Tooltip("生成の間隔")]
    [SerializeField] private float createInterval = 0.3f;

    [Tooltip("生成する高さ")]
    [SerializeField] private float spawnHeight = 4.0f;

    private bool isAttacking = false; // 攻撃中の場合true
    private Vector3 centerPosition; // 生成の中心座標
    private const float CENTER_X = 0.5f; // 画面に対するx座標の割合

    void Start()
    {
        centerPosition = Camera.main.ViewportToWorldPoint(new Vector3(CENTER_X, 0.0f, 0.0f));
    }

    /// <summary>
    /// 氷柱の生成
    /// </summary>
    public void CreateIce()
    {
        if (isAttacking == true)
        {
            return;
        }

        StartCoroutine(IceAttack());
    }

    private IEnumerator IceAttack()
    {
        isAttacking = true;

        List<int> availablePositions = new List<int>();

        for (int count = 0; count < tileCount; count++)
        {
            availablePositions.Add(count);
        }

        while (availablePositions.Count > 0)
        {
            int randomIndex = Random.Range(0, availablePositions.Count); // ランダムにマスを選択
            int positionIndex = availablePositions[randomIndex];
            availablePositions.RemoveAt(randomIndex); // 選択したマスをリストから削除

            // 生成位置の計算
            float startX = centerPosition.x - ((tileCount - 1) * tileSize / 2.0f);
            float spawnX = startX + positionIndex * tileSize;
            Vector3 spawnPosition = new Vector3(spawnX, spawnHeight, 0.0f);
            
            Instantiate(icePrefab, spawnPosition, Quaternion.identity); // 生成

            yield return new WaitForSeconds(createInterval); // 生成後の待機時間
        }

        isAttacking = false;
    }

    /// <summary>
    /// 攻撃中かを取得する
    /// </summary>
    /// <returns>攻撃しているならtrue</returns>
    public bool GetIsAttaking()
    {
        return isAttacking;
    }
}
