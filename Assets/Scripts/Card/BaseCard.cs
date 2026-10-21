using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/// <summary>
/// BaseCardクラス。基本的なカードの挙動を定義するクラス。
/// </summary>

public class BaseCard : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler,IPointerClickHandler,IPointerEnterHandler
{
    private Vector3 defaultPosition;// カードの初期座標

    // カードの状態を表すフラグ
    public bool isUsed; //カードが使用済みかどうか true:使用 false:不使用
    public bool isPassive; //常に存在するカードかどうか true:存在する false:使い切り
    public bool isTrash;//捨てられたかどうか true:捨ててる false:捨ててない
    public bool canTrash;//捨てられるかどうか true:捨てられる false:捨てられない
    public bool isDrag;// カードがドラッグされているかどうか true:ドラッグ中 false:ドラッグしていない

    private int clickCount;// クリックされた回数をカウントする

    public int cardID;//カードの種類を決定するID

    [SerializeField] private CardDataBase cardDataBase;// 参照するカードのデータベース

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardID = Random.Range(0, cardDataBase.CardData.Count);
        CardData data = cardDataBase.CardData[cardID];

        CardVisual cardVisual = GetComponent<CardVisual>();
        cardVisual.SetCardImage(cardID);


        isUsed = false;
        isPassive = false;
        isTrash = false;
        Debug.Log("BaseCard OK");// 確認用ログ
        defaultPosition = Camera.main.WorldToScreenPoint(transform.position);// 初期位置を入れる 
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
        transform.position = defaultPosition; // 初期位置に戻す
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        isDrag = false;
    }



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
        transform.SetAsLastSibling(); // カードを最前面に表示
    }
}
