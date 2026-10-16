using UnityEngine;
using UnityEngine.Rendering;

public class BaseCard : MonoBehaviour
{
   private Vector3 mousePositon;// 取得したマウスの座標
   private Vector3 defaultPosition;// カードの初期座標
   private Vector3 target;// マウスの座標をワールド座標に変換した座標
    [SerializeField]private float playCardZone;// カードが使用判定になるY座標の制限
    float selectCardY;// カードがセレクトされている時のY座標


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("BaseCard OK");// 確認用ログ
        defaultPosition = Camera.main.WorldToScreenPoint(transform.position);// 初期位置を入れる 
        playCardZone = 1;
    }

    // Update is called once per frame
    void Update()
    {
        mousePositon = Input.mousePosition;// マウスの座標を取得
        mousePositon.z = 1;
    }

    /// <summary>
    /// カードをドラッグしている間はマウスと同じ座標にカードがある
    /// </summary>
    private void OnMouseDrag()
    {
        target = Camera.main.ScreenToWorldPoint(mousePositon);
        transform.position=target;
    }
    /// <summary>
    /// カードを離した時に初期位置に戻る
    /// </summary>
    private void OnMouseUp()
    {
        target = Camera.main.ScreenToWorldPoint(mousePositon);
        // カードを使用する判定
        if (target.y> playCardZone)
        {
            Debug.Log("カードを使用しました");
            Destroy(gameObject);
        }
        else
        {
            transform.position = Camera.main.ScreenToWorldPoint(defaultPosition);
        }
        
    }

    private void OnMouseEnter()
    {

    }


}
