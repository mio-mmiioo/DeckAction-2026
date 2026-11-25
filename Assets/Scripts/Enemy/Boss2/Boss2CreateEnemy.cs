using UnityEngine;

public class Boss2CreateEnemy : MonoBehaviour
{
    [Tooltip("EnemyBのPrefabを設定してください")]
    [SerializeField] GameObject enemyBPrefab;

    public void CreateEnemyB(Vector3 position, Transform parent)
    {
        Instantiate(enemyBPrefab, position, Quaternion.identity, parent);
    }
}
