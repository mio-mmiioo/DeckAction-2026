using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] GameObject baseCard;
    [SerializeField] Transform playerHand;


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
            
        }
    }
}
