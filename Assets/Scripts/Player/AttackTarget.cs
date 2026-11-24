using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class AttackTarget : MonoBehaviour
{
    private Transform targetEnemy;

    private CharaHp targetHp;

    private Image targetImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //targetEnemy.transform.position = new Vector2(0, 0);
    }

    public void SetTarget(Transform enemy)
    {
        if(targetEnemy)
        targetImage.enabled = false;        

        targetEnemy = enemy;

        Image[] images = targetEnemy.GetComponentsInChildren<Image>(true);

        targetHp = targetEnemy.GetComponent<CharaHp>();

        targetImage = images.FirstOrDefault(img => img.gameObject.name == "Target");

        targetImage.enabled = true;
    }
    public CharaHp GetTargetHP()
    {
        return targetEnemy.GetComponent<CharaHp>();
    }
}
