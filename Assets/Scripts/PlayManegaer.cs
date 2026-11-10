using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManegaer : MonoBehaviour
{
    private void Update()
    {


        if(transform.childCount == 0)
        {
            Invoke("EnemyDied", 1f);
        }


    }


    private void EnemyDied()
    {


        SceneManager.LoadScene("ClearScene");
    }
}
