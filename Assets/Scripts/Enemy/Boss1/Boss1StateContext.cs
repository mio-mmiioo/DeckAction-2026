using UnityEngine;
using System.Collections.Generic;

public class Boss1StateContext : MonoBehaviour
{
    private IBoss1State currentState; // 現在の状態
    private IBoss1State prevState; // 前回の状態

    Dictionary<ENEMY_A_STATE, IBoss1State> stateTable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
