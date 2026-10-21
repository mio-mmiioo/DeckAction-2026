using UnityEngine;

public class DumyyCard : MonoBehaviour
{

    [SerializeField] private BaseCard child;

    // Update is called once per frame
    void Update()
    {
        transform.Find("BaseCard");
        
    }
}
