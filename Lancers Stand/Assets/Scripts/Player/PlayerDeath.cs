using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeathManager : MonoBehaviour
{

    public GameObject deathScreen;

    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathScreen.SetActive(false);
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.health <= 0)
        {
            player.SetActive(false);
            deathScreen.SetActive(true);
        }
    }


    public void MenuButton()
    {
        
        GlobalVariables.currentScene = "MainMenu";
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButton()
    {

        SceneManager.LoadScene("SampleScene");
        player.SetActive(true);
        deathScreen.SetActive(false);
    }
}
