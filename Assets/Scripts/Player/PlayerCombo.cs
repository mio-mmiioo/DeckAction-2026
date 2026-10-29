using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
    [SerializeField] CardManager cardManager;

    private float cardSetTime;
    private float cardSetElapsedTime;
    private float comboLimitTime;

    private int prevCardID;
    private int currentCardID;
    public int comboCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardSetTime = 1.5f;
        comboLimitTime = 5.0f;
        cardSetElapsedTime = 0f;
        currentCardID = 0;
        prevCardID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCardID==0||cardSetTime<=cardSetElapsedTime)
        {
            ComboJudge();
        }
        else if(comboLimitTime<cardSetElapsedTime)
        {
            comboCount = 0;
        }
        else
        {
            cardSetElapsedTime += Time.deltaTime;
        }


    }

  public  int ComboJudge()
    {
        currentCardID = cardManager.GetUseCard();
        cardSetElapsedTime = 0;

        if (currentCardID != 0)
        {
            comboCount++;
            prevCardID = currentCardID;
            return comboCount;
        }
        else
        {
            comboCount = 0;

        }

        return 0;

    }
}
