using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// BaseCardクラス。基本的なカードの挙動を定義するクラス。
/// </summary>

public class BaseCard : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{

    // カードの状態を表すフラグ

    [Tooltip("//カードが使用済みかどうか true:使用 false:不使用")]
    public bool isUsed;

    [Tooltip("常に存在するカードかどうか true:存在する false:使い切り")]
    public bool isPassive;

    [Tooltip("捨てられたかどうか true:捨ててる false:捨ててない")]
    public bool isTrash;

    [Tooltip("捨てられるかどうか true:捨てられる false:捨てられない")]
    public bool canTrash;

    [Tooltip("カードがドラッグされているかどうか true:ドラッグ中 false:ドラッグしていない")]
    public bool isDrag;

    [Tooltip("カードが選択状態かどうか true:選択中 false:未選択")]
    public bool isPick;

    private int clickCount;// クリックされた回数をカウントする

    [HideInInspector]
    public int cardID;//カードの種類を決定するID

    [SerializeField] private CardDataBase cardDataBase;// 参照するカードのデータベース

    // カードの配置を記憶しておく変数
    private Vector3 localScale;// サイズ
    private Vector2 localPosition;// 位置
    private int prevSiblingIndex;// 表示順

    void Awake()
    {
        cardID = Random.Range(1, cardDataBase.CardData.Count);
        SetCardView(cardID);
    }

    /// <summary>
    /// 変数の初期化
    /// </summary>
    void Start()
    {
        isDrag = false;
        isUsed = false;
        isPassive = false;
        isTrash = false;
        Debug.Log("BaseCard OK");// 確認用ログ
        localScale = transform.localScale;
        
    }

    /// <summary>
    /// ドラッグ開始時にレイキャストの判定をオフにする
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isUsed)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            isDrag = true;
        }
    }


    /// <summary>
    /// ドラッグ中はマウスポインターと同じ座標にする
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        if(!isUsed)
        {
            transform.position = eventData.position;
        }
        
    }

    /// <summary>
    /// ドラッグ終了時にカードを使用したか、初期位置に戻すかを判定し、レイキャストもオンにする
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isUsed)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            isDrag = false;
            OnPointerExit(eventData);
        }
        
    }


    /// <summary>
    /// デバッグ用破壊時のメッセージ
    /// </summary>
    void OnDestroy()
    {
        Debug.Log("BaseCard 破棄");
    }


    /// <summary>
    /// 一回のクリックで0.3秒後にダブルクリックかどうかを判定する関数
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        clickCount++;
        Invoke("OnDoubleClick", 0.3f);
    }

    /// <summary>
    /// ダブルクリックされた場合にカードを使用済みにする関数
    /// </summary>
    private void OnDoubleClick()
    {
        if(clickCount!=2)
        {
            clickCount = 0;
        }

        if (clickCount >= 2)
        {
            Debug.Log("カードがダブルクリックされました");
            isUsed = true;
            clickCount = 0;
        }
        
    }

    /// <summary>
    ///  カードの上にマウスを乗せた時に拡大表示する
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        localPosition = transform.position;
        if (!isUsed)
        {
            localPosition = transform.position;
            Vector2 checkPos =new Vector2(localPosition.x, localPosition.y*2.0f);
            
            if (!Input.GetMouseButton(0))
            {
                transform.localScale = localScale * 1.3f;
                transform.position = checkPos;
                prevSiblingIndex = transform.GetSiblingIndex();
                transform.SetAsLastSibling();
            }
            
        }
        
    }

    /// <summary>
    /// カードからマウスを離した時にもとに戻す
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isDrag)
        {
            transform.localScale = localScale;
            transform.position = localPosition;
            transform.SetSiblingIndex(prevSiblingIndex);
        }
            
    }

    /// <summary>
    /// カードのビジュアルを決定する
    /// </summary>
    /// <param name="id"></param>
    public void SetCardView(int id)
    {
        cardID = id;

        CardVisual cardVisual = GetComponent<CardVisual>();
        cardVisual.SetCardImage(cardID);
    }

    
}
