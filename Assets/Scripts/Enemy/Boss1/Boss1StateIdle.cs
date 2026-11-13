using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1StateIdle : IBoss1State
{
    private Boss1 boss1;

    private GameObject player;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private const float IDLE_TIME = 5.0f; // 待機の時間
    private float idleTimer;

    private bool isEndIdle;


    public Boss1StateIdle(Boss1 b) => boss1 = b;


    public BOSS_1_STATE state => BOSS_1_STATE.B_1_STATE_IDLE;


    public void Entry()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = boss1.GetComponent<Rigidbody2D>();
        spriteRenderer = boss1.GetComponent<SpriteRenderer>();
        animator = boss1.GetComponent<Animator>();
        idleTimer = IDLE_TIME;
        animator.SetTrigger("Idle");
        isEndIdle = false;

    }

    public void Exit()
    {

    }


    // Update is called once per frame
    public void Update()
    {
        if (idleTimer > 0.0f)
        {
            idleTimer -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Boss1StateIdle: Change to Jump");
            isEndIdle = true;
        }

        if(isEndIdle)
        {
            boss1.Jump();
        }



    }
}