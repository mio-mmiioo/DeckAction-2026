using Unity.VisualScripting;
using UnityEngine;

public class Boss1Shadow : MonoBehaviour
{
    private float shadowHeiht;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shadowHeiht= transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3(transform.position.x, shadowHeiht,transform.position.z);
    }
}
