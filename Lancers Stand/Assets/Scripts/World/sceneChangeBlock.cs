using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChangeBlock : MonoBehaviour
{

    public string targetScene;
    private SceneFader sceneFader;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetScene);
            GlobalVariables.currentScene = targetScene;
        }
    }
    
}