using System.Linq;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject enemyAPrefab;
    [SerializeField] GameObject enemyBPrefab;
    [SerializeField] GameObject boss2Prefab;

    public struct SpawnEnemyData
    {
        public GameObject prefab;
        public Vector3 spawnPosition;

        public SpawnEnemyData(GameObject pre, Vector3 sPosition)
        {
            prefab = pre;
            spawnPosition = sPosition;
        }
    }

    SpawnEnemyData[] wave2;

    void Start()
    {
        wave2 = new SpawnEnemyData[]
        {
            new SpawnEnemyData(enemyBPrefab, new Vector3(4.0f, 0.0f, 0.0f)),
            new SpawnEnemyData(enemyBPrefab, new Vector3(6.0f, 0.0f, 0.0f))
        };
    }

    /// <summary>
    /// ウェーブ2を生成
    /// </summary>
    /// <returns>敵の数</returns>
    public int CreateWave2()
    {
        CreateEnemy(wave2);
        return wave2.Length;
    }

    public GameObject CreateWave2Boss()
    {
        GameObject ret;
        ret = Instantiate(boss2Prefab, new Vector3(4.0f, 0.0f, 0.0f), Quaternion.identity, transform);
        return ret;
    }

    /// <summary>
    /// 敵を生成する
    /// </summary>
    /// <param name="enemyData">生成する敵のデータ</param>
    public void CreateEnemy(SpawnEnemyData[] enemyData)
    {
        foreach(SpawnEnemyData enemy in enemyData)
        {
            Instantiate(enemy.prefab, enemy.spawnPosition, Quaternion.identity, transform);
        }
    }
}
