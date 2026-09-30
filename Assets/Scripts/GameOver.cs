using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void GameOveButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
