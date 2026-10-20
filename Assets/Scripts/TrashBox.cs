using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ゴミ箱のスクリプト
/// </summary>
public class TrashBox : MonoBehaviour,IDropHandler
{

    /// <summary>
    /// 上でカードが離されると捨てる
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {   
            Debug.Log("カードを破棄しました");
            Destroy(droppedObject);
        }
    }


}
