using UnityEngine;
using UnityEngine.EventSystems;

public class PlayField : MonoBehaviour,IDropHandler
{
    /// <summary>
    /// 上でカードが離されると使用
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {
            BaseCard card = droppedObject.GetComponent<BaseCard>();
            if(card!=null)
            {
                card.isUsed = true;
                Debug.Log("カードが使用されました");
            }
            
        }
    }
}
