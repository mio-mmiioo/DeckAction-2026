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
    private Vector3 defaultPosition;// カードの初期座標

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

    private Vector3 localScale;
    private Vector2 localPosition;
    private int prevSiblingIndex;
    private Outline uiOutline;


    void Awake()
    {
        cardID = Random.Range(1, cardDataBase.CardData.Count);
        SetCardView(cardID);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDrag = false;
        isUsed = false;
        isPassive = false;
        isTrash = false;
        Debug.Log("BaseCard OK");// 確認用ログ
        defaultPosition = Camera.main.WorldToScreenPoint(transform.position);// 初期位置を入れる 
        uiOutline = GetComponent<Outline>();
        localScale = transform.localScale;
        
    }

    void Update()
    {
        if(isPick)
        {
            uiOutline.enabled = true;
        }
        else
        {
            uiOutline.enabled = false;
        }
    }

    /// <summary>
    /// ドラッグ開始時にレイキャストの判定をオフにする
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPosition = transform.position; // ドラッグ開始時の位置を保存
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        isDrag = true;
    }


    /// <summary>
    /// ドラッグ中はマウスポインターと同じ座標にする
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    /// <summary>
    /// ドラッグ終了時にカードを使用したか、初期位置に戻すかを判定し、レイキャストもオンにする
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = defaultPosition; // 初期位置に戻す
        isDrag = false;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isUsed)
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

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isUsed)
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
