using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySetTarget : MonoBehaviour
{
    [SerializeField] private AttackTarget attackTarget;

     List<Transform> enemyList=new List<Transform>();

    private int currentTarget;

    private Transform clickedTarget;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = 0;
        //enemy = transform.position;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if(child.CompareTag("Enemy"))
            {
                enemyList.Add(child);
            }

        }
        
       // attackTarget.SetTarget(enemyList[currentTarget]);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ClickTarget();
        }
    }

    public void sssm()
    {
        if(currentTarget<enemyList.Count)
        {
            currentTarget++;
            attackTarget.SetTarget(enemyList[currentTarget]);
        }
        
    }

    private void ClickTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit2d)
        {
            clickedTarget = hit2d.transform;
            for(int i=0;i<enemyList.Count;i++)
            {
                if (enemyList[i]==clickedTarget)
                {
                    attackTarget.SetTarget(enemyList[i]);
                    Debug.Log("ターゲットおん");
                }
            }
        }

    }
        
}
