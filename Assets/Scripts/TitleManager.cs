using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Buttonコンポーネントの OnClick() にこのメソッドを登録する
    public void OnStartButton()
    {
        SceneManager.LoadScene("PlayScene");
        Debug.Log("StartButtonが押されました");
    }

    public void OnQuitButton()
    {
        // エディタ上では動作しない（ビルド後のみ有効）
       // Application.Quit();
    }


}
