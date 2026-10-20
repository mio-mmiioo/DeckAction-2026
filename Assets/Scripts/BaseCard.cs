using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/// <summary>
/// BaseCardクラス。基本的なカードの挙動を定義するクラス。
/// </summary>
public class BaseCard : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
   private Vector3 defaultPosition;// カードの初期座標

    [SerializeField]private float playCardZone;// カードの使用可能なゾーンのY座標

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("BaseCard OK");// 確認用ログ
        defaultPosition = Camera.main.WorldToScreenPoint(transform.position);// 初期位置を入れる 
        playCardZone = 1;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    /// <summary>
    /// ドラッグ開始時にレイキャストの判定をオフにする
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPosition = transform.position; // ドラッグ開始時の位置を保存
        GetComponent<CanvasGroup>().blocksRaycasts = false;
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
        //if(transform.position.y > playCardZone)
        //{
        //    Debug.Log("カードを使用しました");
        //}
        //else
        //{
            
        //}
        transform.position = defaultPosition; // 初期位置に戻す
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
