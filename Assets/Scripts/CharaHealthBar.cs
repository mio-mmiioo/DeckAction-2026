using System;
using UnityEngine;
using UnityEngine.UI;

public class ChraHealthBar : MonoBehaviour
{
    private Slider hpSlider;// スライダー
    private CharaHp charaHp;// キャラクターのHPの数値
    private RectTransform rectTransform;// スライダーのトランスフォーム
    private Vector3 originalScale;// 基準の大きさ
    [SerializeField] private bool isBoss;// ボス用のHPバーならtrue
    private bool isSetBossHP;// ボスのHPがセットされたならtrue
    Image[] sliderImage;// スライダーの画像
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charaHp = GetComponentInParent<CharaHp>();
        hpSlider = GetComponent<Slider>();
        rectTransform = GetComponent<RectTransform>();
        sliderImage = GetComponentsInChildren<Image>();

        hpSlider.maxValue = charaHp.GetMaxHP();
        originalScale= rectTransform.localScale;
        isSetBossHP = false;

        if (isBoss)
        {
            SetSliderImage(false);
        }

    }

    /// <summary>
    /// Updateの最後にHPの反映と、バーの反転処理をする
    /// </summary>
    void LateUpdate()
    {
        if(isBoss)
        {
            SetBossHP();

        }

        if(charaHp==null)
        {
            SetSliderImage(false);
            isSetBossHP = false;
        }
        else
        {
            // キャラクターが反転したときに向きをそのままにするため、マイナスを入れる
            if (transform.parent.parent.localScale.x < 0)
            {
                rectTransform.localScale = new Vector3(originalScale.x * -1, originalScale.y, originalScale.z);
            }
            else
            {
                rectTransform.localScale = originalScale;
            }

            // HPの反映
            hpSlider.value = charaHp.GetHP();
        }
        
    }

    private void SetBossHP()
    {
        if (!isSetBossHP)
        {
            CharaHp[] chara = GetComponents<CharaHp>();

            foreach (CharaHp hp in chara)
            {
                if (hp.CompareTag("Boss"))
                {
                    charaHp = hp;

                }
            }
            SetSliderImage(true);
            isSetBossHP = true;
        }
    }

    private void SetSliderImage(bool enable)
    {
        foreach(Image image in sliderImage)
        {
            image.enabled = enable;
        }
    }

}
