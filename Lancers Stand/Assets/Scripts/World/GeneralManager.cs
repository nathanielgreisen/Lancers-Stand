using UnityEngine;
using UnityEngine.SceneManagement;

public class generalManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] interactionBlocks = GameObject.FindGameObjectsWithTag("InteractionBlocks");

        foreach (GameObject block in interactionBlocks)
        {
            SpriteRenderer sr = block.GetComponent<SpriteRenderer>();

            sr.sprite = Resources.Load<Sprite>("Sprites/LetterIcons/" + GlobalVariables.interactKey.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public static System.Collections.IEnumerator DeathFade(GameObject deathObject)
    {

        SpriteRenderer sr = deathObject.GetComponent<SpriteRenderer>();
        Color c = sr.color;

        float fadeDuration = 2f; // I'm hardcoding this bc its not working outside and idk why

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            sr.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }

        Destroy(deathObject);
    }
}
