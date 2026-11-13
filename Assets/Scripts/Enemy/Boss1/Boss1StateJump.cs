using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1StateJump : IBoss1State
{
    private Boss1 boss1;

    private GameObject player;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector2 landingPoint;
    
    private Vector2 jumpingPoint;
    private float cameraOutHeight = 10.0f;//カメラの外に出れる高さ

    private const float CHARGE_TIME = 3.0f; // 攻撃前のための時間
    private float chargeTimer;
    private const float LANDING_TIME = 1.0f; // 着地までのための時間
    private float landingTimer;
    private const float JUMP_SPEED = 0.03f;//ジャンプの時間
    private float jumpSpeed;

    private bool isEndJump ;
    private bool isJumping ;
    private bool isLanding ;

    public Boss1StateJump(Boss1 b) => boss1 = b;


    public BOSS_1_STATE state => BOSS_1_STATE.B_1_STATE_JUMP;


    public void Entry()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = boss1.GetComponent<Rigidbody2D>();
        spriteRenderer = boss1.GetComponent<SpriteRenderer>();
        animator = boss1.GetComponent<Animator>();
        chargeTimer= CHARGE_TIME;
        landingTimer= LANDING_TIME;
        jumpSpeed = JUMP_SPEED;

        SetLandingPoint();
        animator.SetTrigger("Charge");
        Debug.Log("Boss1StateJump: Entry");

        isEndJump = false;
        isJumping = false;
        isLanding = false;

    }

    public void Exit()
    {

    }


    // Update is called once per frame
    public void Update()
    {
        if(chargeTimer>0.0f)
        {
            chargeTimer -= Time.deltaTime; 
        }
        else
        {
            Jump();
        }

        if(isEndJump)
        {
            boss1.Idle();
        }

    }

    /// <summary>
    /// 着地地点を設定する
    /// </summary>
    private void SetLandingPoint()
    {
        //プレイヤーの位置が着地地点
        landingPoint= player.transform.position;

        //ジャンプで移動する場所
        jumpingPoint = new Vector2(landingPoint.x, cameraOutHeight);

    }

    private void Jump()
    {
        if(!isJumping)
        {
            isJumping = true;
            animator.SetTrigger("Jump");
        }


        if (boss1.transform.position.y!=cameraOutHeight&&!isLanding)
        {
            boss1.transform.position =Vector2.MoveTowards(boss1.transform.position, jumpingPoint, jumpSpeed);
        }
        else if(boss1.transform.position.y<=cameraOutHeight)
        {
            if (landingTimer > 0.0f)
            {
                landingTimer -= Time.deltaTime;
            }
            else
            {
               Landing();
            }

            
        }



    }

    private void Landing()
    {
        isLanding = true;

        animator.SetTrigger("Idle");

        boss1.transform.position = Vector2.MoveTowards(
            boss1.transform.position,
            landingPoint,
            jumpSpeed
        );

        if (Vector2.Distance(boss1.transform.position, landingPoint) < 0.01f)
        {
            isEndJump = true;
        }
    }



    /// <summary>
    /// プレイヤーの位置から画像の向きを設定する
    /// </summary>
    private void SetSpriteFlip()
    {
        Vector3 playerPos = player.transform.position;
        if (boss1.transform.position.x < playerPos.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

    }
}
