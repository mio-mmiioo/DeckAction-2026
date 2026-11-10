using TMPro;
using UnityEngine;

public class ComboCount : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI comboCount;

    private string comboText;

    private void Start()
    {
        comboText = "COMBO!";
    }

    // Update is called once per frame
    public void SetComboCount(int count)
    {
        if(count>0)
        {
            string text = count.ToString();

            comboCount.text = text + comboText;
        }
        else
        {
            comboCount.text = "";
        }

        


    }
}
