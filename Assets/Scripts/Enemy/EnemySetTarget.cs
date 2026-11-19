using UnityEngine;
using UnityEngine.EventSystems;

public class EnemySetTarget : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Player player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player.GetTarget();
        if(player!=null)
        {
            //canvsの枠を表示
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //player.SetTarget(this);

    }
}
