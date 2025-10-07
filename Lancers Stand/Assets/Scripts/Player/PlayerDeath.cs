using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathManager : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject healthBox;

    public GameObject player;

    // private SceneFader sceneFader;

    void Start()
    {
        deathScreen.SetActive(false);
        player.SetActive(true);
        healthBox.SetActive(true);
    }

    void Update()
    {
        if (GlobalVariables.health <= 0)
        {
            player.SetActive(false);
            deathScreen.SetActive(true);
            healthBox.SetActive(false);
        }
    }

public void DeathButton(string screen)
    {
        // StartCoroutine(sceneFader.FadeOutIn(screen));
        SceneManager.LoadScene(screen);

        GlobalVariables.currentScene = screen;
        GlobalVariables.maxHealth = 10.0;
        GlobalVariables.health = GlobalVariables.maxHealth;
        GlobalVariables.focusLocked = false;
        GlobalVariables.cameraLocked = false;
        GlobalVariables.isAttacking = false;
        GlobalVariables.isDamaging = false;
    }
}
