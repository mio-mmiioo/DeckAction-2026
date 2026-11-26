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

    private float deleteTimer;


    void Start()
    {
        cardManager = FindAnyObjectByType<CardManager>();
        deleteTimer = DELETE_TIME;
    }

    void Update()
    {
        if (deleteTimer > 0)
        {
            deleteTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag==("Player"))
        {
            cardManager.enemyTurnDrawCard++;

            Destroy(gameObject);
        }

    }
}
