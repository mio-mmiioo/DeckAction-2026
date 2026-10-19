using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;

public class BaseCard : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
   private Vector3 defaultPosition;// カードの初期座標
    [SerializeField]private float playCardZone;// カー

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

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    /// <summary>
    /// ドラッグ中はマウスポインターと同じ座標に
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    { 
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.position.y > playCardZone)
        {
            Debug.Log("カードを使用しました");
        }
        else
        {
            transform.position = Camera.main.ScreenToWorldPoint(defaultPosition);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
