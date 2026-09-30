using System.Timers;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    float GameTime; //the speed the game was at when the has neem paused
    bool GamePaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused == false)
            {
                PauseGame();
            }
            else
            {
               UnPauseGame();
            }

        }
    }
    public void PauseGame()
    {
        GamePaused = true;
        GameTime = Time.timeScale;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void UnPauseGame()
    {
        GamePaused = false;
        Time.timeScale = GameTime;
        pauseScreen.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
