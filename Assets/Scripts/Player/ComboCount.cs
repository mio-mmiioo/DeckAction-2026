using TMPro;
using UnityEngine;

public class ComboCount : MonoBehaviour
{
    private RectTransform textTransform;
    private Vector3 textPosition;
    private Vector3 originalScale;
    private Vector3 originalPosition;
   [SerializeField] private TextMeshProUGUI comboCount;

    private string comboText;

    private void Start()
    {
        comboText = "COMBO!";
        textTransform = comboCount.rectTransform;
        originalScale = comboCount.rectTransform.localScale;
    }

    private void Update()
    {
        if(comboCount.rectTransform.position.x<0)
        {
            //comboCount.rectTransform.position = new Vector3(comboCount.rectTransform.position.x * -1, comboCount.rectTransform.position.y, comboCount.rectTransform.position.z);
        }
    }


    /// <summary>
    /// Updateの一番最後に表示の反転処理をする
    /// </summary>
    public void LateUpdate()
    {
        if (transform.localScale.x < 0)
        {
            textTransform.localScale = new Vector3(originalScale.x * -1, originalScale.y, originalScale.z);
        }
        else
        {
            textTransform.localScale = originalScale;
            
        }
        
        comboCount.rectTransform.localScale = textTransform.localScale;
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
