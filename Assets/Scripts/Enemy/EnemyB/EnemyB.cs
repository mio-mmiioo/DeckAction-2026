using UnityEngine;

public class EnemyB : MonoBehaviour
{
    private EnemyBStateContext stateContext;
    
    void Start()
    {
        stateContext = GetComponent<EnemyBStateContext>();
        stateContext.Init(this, ENEMY_B_STATE.E_B_STATE_MOVE);
    }

    public void Move()
    {
        stateContext.ChangeState(ENEMY_B_STATE.E_B_STATE_MOVE);
    }
}
