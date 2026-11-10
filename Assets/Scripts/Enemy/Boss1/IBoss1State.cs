using UnityEngine;

public interface IBoss1State 
{

    ENEMY_BOSS1_STATE state { get; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public enum ENEMY_BOSS1_STATE
    { 
        B_1_STATE_JUMP,
        B_1_STATE_IDLE


    }


}
