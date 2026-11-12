using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void OnTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
        Debug.Log("TitleButtonが押されました");
    }

    public void OnQuitButton()
    {
        // エディタ上では動作しない（ビルド後のみ有効）
        // Application.Quit();
    }
}
