using UnityEngine;
using UnityEngine.EventSystems;

public class PlayField : MonoBehaviour,IDropHandler
{
    private CharaSetAttackTurn charaSetAttackTurn;

    void Start()
    {
        charaSetAttackTurn = GameObject.FindGameObjectWithTag("Player").GetComponent<CharaSetAttackTurn>();
    }

    /// <summary>
    /// 上でカードが離されると使用
    /// </summary>
    /// <param name="eventData"></param>
    /// 
    public void OnDrop(PointerEventData eventData)
    {
        if (charaSetAttackTurn.GetIsAttackTurn())
        {
            GameObject droppedObject = eventData.pointerDrag;
            if (droppedObject != null)
            {
                BaseCard card = droppedObject.GetComponent<BaseCard>();
                if (card != null)
                {
                    card.isUsed = true;
                    Debug.Log("カードが使用されました");
                }
            }
        }
    }
}
