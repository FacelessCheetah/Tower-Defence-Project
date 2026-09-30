using TMPro;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    [Header("health")]
    public int health;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject gameOverScreen;
    private void Start()
    {
        healthText.SetText("Lives: " + health);
    }
    public void updateHealth(int enemyHealth)
    {
        health -= enemyHealth;
        healthText.SetText("Lives: " + health);
        if (health <= 0)
        {
            Time.timeScale = Mathf.Epsilon;
            gameOverScreen.SetActive(true);
        }
    }
}
