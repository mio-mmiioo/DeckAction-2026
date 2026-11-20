using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    private GameObject targetEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetEnemy.transform.position = new Vector2(0, 0);
    }

    public void SetTarget(GameObject enemy)
    {
        targetEnemy = enemy;
    }
    public CharaHp GetTargetHP()
    {
        return targetEnemy.GetComponent<CharaHp>();
    }
}
