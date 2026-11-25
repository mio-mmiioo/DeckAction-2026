using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerCombo : MonoBehaviour
{
    private int prevCardID;// 前回のカード
    private int currentCardID;// 現在のカード
    [SerializeField] private int comboCount; //コンボ数

    private List<int> comboList = new List<int>();

    void Start()
    {
        prevCardID = 0;
        currentCardID = 0;
    }

    /// <summary>
    /// コンボ回数を返す    
    /// </summary>
    public int ComboJudge(int type)
    {
        currentCardID = type;

        if(comboCount==0)
        {
            comboCount++;
        }
        else
        {
            if (prevCardID == currentCardID)
            {
                comboCount++;
            }
            else
            {
                comboCount = 0;
            }
        }
        prevCardID = currentCardID;
        return comboCount;

    } 

    public void ResetCombo()
    {
        prevCardID = 0;
        currentCardID = 0;
        comboCount = 0;
    }
}
