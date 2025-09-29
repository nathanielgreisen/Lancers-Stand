using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeathManager : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject healthBox;

    public GameObject player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathScreen.SetActive(false);
        player.SetActive(true);
        healthBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.health <= 0)
        {
            player.SetActive(false);
            deathScreen.SetActive(true);
            healthBox.SetActive(false);
        }
    }


    public void MenuButton()
    {

        SceneManager.LoadScene("MainMenu");

        GlobalVariables.currentScene = "MainMenu";
        GlobalVariables.health = 5;
        GlobalVariables.maxHealth = 5.0;
        GlobalVariables.focusLocked = false;
        GlobalVariables.isAttacking = false;
        GlobalVariables.isDamaging = false;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        
        GlobalVariables.currentScene = "SampleScene";
        GlobalVariables.health = 5;
        GlobalVariables.maxHealth = 5.0;
        GlobalVariables.focusLocked = false;
        GlobalVariables.isAttacking = false;
        GlobalVariables.isDamaging = false;
    }
}
