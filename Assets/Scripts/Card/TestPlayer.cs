using TMPro;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    [SerializeField] private TextMeshProUGUI nameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            int i=cardManager.GetUseCard();
            if (i == 0) return;

            nameText.text = i.ToString();

        }
    }
}
