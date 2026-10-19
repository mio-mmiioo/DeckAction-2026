using UnityEngine;
using UnityEngine.EventSystems;

public class DustBox : MonoBehaviour,IDropHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {   
            Debug.Log("カードを破棄しました");
        }
    }


}
