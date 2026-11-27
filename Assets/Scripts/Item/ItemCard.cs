using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

/// <summary>
/// エネミターン中に拾うカード
/// </summary>
public class ItemCard : MonoBehaviour
{
    private CardManager cardManager;

    private float DELETE_TIME = 5.0f;

    private float deleteTimer;//消去用タイマー

    private float startPos;//スタート時点でのY座標    

    private float updownSpeed;//上下の速度
    void Start()
    {
        cardManager = FindAnyObjectByType<CardManager>();
        deleteTimer = DELETE_TIME;
        startPos = transform.position.y;
        updownSpeed = 2.0f;
    }

    void Update()
    {
        // タイマーが過ぎたら消去
        if (deleteTimer > 0)
        {
            deleteTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

        // ふわふわ浮かせる
        float updown= startPos + Mathf.Cos(Time.time * updownSpeed) * 0.25f;//上下の動き

        transform.position = new Vector2(transform.position.x, updown);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag==("Player"))
        {
            cardManager.enemyTurnDrawCard += 1;

            Destroy(gameObject);
        }

    }
}
