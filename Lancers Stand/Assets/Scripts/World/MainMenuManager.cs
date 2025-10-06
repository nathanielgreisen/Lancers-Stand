using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject creditsButton;
    public GameObject tutorialCheck;
    public GameObject settings;
    public GameObject credits;

    public TMP_Text quitTag;
    public Toggle tutorialToggle;

    public void Start()
    {
        settings.SetActive(false);
        credits.SetActive(false);
        tutorialToggle.isOn = GlobalVariables.tutorialEnabled;
        tutorialToggle.onValueChanged.AddListener(SetTutorial);

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GlobalVariables.currentScene == "MainMenu")
            {
                QuitGame();
            }
            else
            {
                ReturnMenu();
            }
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void EnableSettings()
    {
        GlobalVariables.currentScene = "Settings";
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        creditsButton.SetActive(false);
        tutorialCheck.SetActive(false);
        
        credits.SetActive(false);
        settings.SetActive(true);
        quitTag.text = "Press Escape to Return to Menu!";
    }

    public void EnableCredits()
    {
        GlobalVariables.currentScene = "Credits";
        playButton.SetActive(false);
        settingsButton.SetActive(false);
        creditsButton.SetActive(false);
        tutorialCheck.SetActive(false);
        
        credits.SetActive(true);
        settings.SetActive(false);
        quitTag.text = "Press Escape to Return to Menu!";
    }

    public void ReturnMenu()
    {
        GlobalVariables.currentScene = "MainMenu";
        playButton.SetActive(true);
        settingsButton.SetActive(true);
        creditsButton.SetActive(true);
        tutorialCheck.SetActive(true);

        settings.SetActive(false);
        credits.SetActive(false);
        quitTag.text = "Press Escape to Quit!";
    }
    
    public void SetTutorial(bool tutorialToggle)
    {
        if (tutorialToggle) { GlobalVariables.tutorialEnabled = true; }
        else { GlobalVariables.tutorialEnabled = false; }
        
        Debug.Log("Tutorial: " + (tutorialToggle ? "Enabled" : "Disabled"));
    }

    
}
