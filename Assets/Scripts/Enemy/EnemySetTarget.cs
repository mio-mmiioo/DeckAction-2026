using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemySetTarget : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private AttackTarget attackTarget;

    private GameObject enemy;

    private Image target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GetComponentInChildren<Image>();
        target.enabled = false;
        //enemy = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //attackTarget.SetTarget(enemy);
        target.enabled = true;
    }
}
