using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaBar : MonoBehaviour
{
    private Slider staminaSlider;
   [SerializeField] private Stamina playerStamina;
    private RectTransform rectTransform;
    private Vector3 originalScale;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        staminaSlider = GetComponent<Slider>();
        rectTransform=GetComponent<RectTransform>();
        staminaSlider.maxValue = playerStamina.GetMaxStamina();
        originalScale= rectTransform.localScale;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        staminaSlider.value = playerStamina.GetCurrentStamina();
    }
}
