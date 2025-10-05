using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;
    public Image fadeImage;
    public Toggle tutorialToggle;
    public GameObject FadingCanvas;
    public float fadeDuration = 1f;

    void Awake()
    {
        DontDestroyOnLoad(FadingCanvas); // Keeps the fading canvas there to ensure smooth fading between scenes
    }

    void Start()
    {
        StartCoroutine(FadeIn(3)); // When game first opens, fade in
    }

    public void FadeToScene(string sceneName)
    {
        if (GlobalVariables.tutorialEnabled)
        {
            StartCoroutine(FadeOutIn("Tutorial")); // Command to fade into a scene
            GlobalVariables.tutorialEnabled = false;
            tutorialToggle.isOn = false;

        }
        else
        {
            StartCoroutine(FadeOutIn(sceneName)); // Command to fade into a scene
        }
        
    }

    private IEnumerator FadeIn(int duration = 1)
    {

        float t = duration;
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            color.a = Mathf.Clamp01(t / duration);
            fadeImage.color = color;
            yield return null;
        }
    }

    public IEnumerator FadeOutIn(string sceneName)
    {

        // Fade out
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Load new scene
        yield return SceneManager.LoadSceneAsync(sceneName);

        // Fade in after load
        yield return FadeIn();
    }
}
