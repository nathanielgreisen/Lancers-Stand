using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChangeBlock : MonoBehaviour
{

    public string targetScene;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the SceneFader instance and use it to fade to the target scene
            SceneFader sceneFader = FindFirstObjectByType<SceneFader>();
            if (sceneFader != null)
            {
                sceneFader.FadeToScene(targetScene);
            }
            else
            {
                // Fallback to direct scene loading if SceneFader is not found
                SceneManager.LoadScene(targetScene);
                GlobalVariables.currentScene = targetScene;
            }
        }
    }
    
}