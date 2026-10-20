using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] BaseCard baseCard;
    [SerializeField] Transform playerHand;
    List<BaseCard> hands = new List<BaseCard>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(baseCard, playerHand);
        Debug.Log("CardManager OK");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            AddHands(1);
        }
    }

    public void AddHands(int value)
    {
        for(int i=0;i<value;i++)
        {
            BaseCard obj =Instantiate(baseCard, playerHand);
            hands.Add(obj);
        }
        
    }
}
