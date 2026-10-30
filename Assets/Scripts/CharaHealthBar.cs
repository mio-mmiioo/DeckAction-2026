using System;
using UnityEngine;
using UnityEngine.UI;

public class ChraHealthBar : MonoBehaviour
{
    private Slider hpSlider;// スライダー
    private CharaHp charaHp;// キャラクターのHPの数値
    private RectTransform rectTransform;// スライダーのトランスフォーム
    private Vector3 originalScale;// 基準の大きさ
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charaHp = GetComponentInParent<CharaHp>();
        hpSlider = GetComponent<Slider>();
        rectTransform = GetComponent<RectTransform>();
        hpSlider.maxValue = charaHp.GetMaxHP();
        originalScale= rectTransform.localScale;
    }

    /// <summary>
    /// Updateの最後にHPの反映と、バーの反転処理をする
    /// </summary>
    void LateUpdate()
    {
        // キャラクターが反転したときに向きをそのままにするため、マイナスを入れる
        if(transform.parent.parent.localScale.x<0)
        {
            rectTransform.localScale = new Vector3(originalScale.x*-1, originalScale.y, originalScale.z);
        }
        else
        {
            rectTransform.localScale = originalScale;
        }
      
        // HPの反映
        hpSlider.value = charaHp.GetHP();
    }

}
