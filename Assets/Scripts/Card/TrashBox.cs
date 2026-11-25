using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ゴミ箱のスクリプト
/// </summary>
public class TrashBox : MonoBehaviour,IDropHandler
{
    private CharaSetAttackTurn charaSetAttackTurn;

    void Start()
    {
        charaSetAttackTurn = GameObject.FindGameObjectWithTag("Player").GetComponent<CharaSetAttackTurn>();
    }


    /// <summary>
    /// 上でカードが離されると捨てる
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        if(charaSetAttackTurn.GetIsAttackTurn())
        {
            GameObject droppedObject = eventData.pointerDrag;
            if (droppedObject != null)
            {
                BaseCard card = droppedObject.GetComponent<BaseCard>();
                card.isTrash = true;
            }
        }
    }


}
