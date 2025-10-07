using UnityEngine;

public class Health : MonoBehaviour
{

    public GameObject HealthBackground;

    private int initHealth; // The current number of initialized health objects in HealthBackground

    void Update() //TODO: Something in here is making the hearts generate slightly big for some reason when using debug
    {
        initHealth = HealthBackground.transform.childCount;
        if (initHealth < GlobalVariables.health && initHealth > 0) //When hearts are added
        {
            // Get the first existing heart to copy from
            Transform existingHeart = HealthBackground.transform.GetChild(0);
            GameObject heart = Instantiate(existingHeart.gameObject); // Duplicate existing heart
            heart.transform.SetParent(HealthBackground.transform, false); // Move it to the correct location (false preserves local scale)
            heart.name = "heart"; // Renaming it so it looks better
            
            // Explicitly set the local scale to match the original (fixes build scaling issues)
            heart.transform.localScale = existingHeart.localScale;
        }
        else if (initHealth > GlobalVariables.health && initHealth > 0) //When hearts are removed
        {
            Transform firstChild = HealthBackground.transform.GetChild(0); //Gets the first child
            Destroy(firstChild.gameObject); // Destroys it (wow thats brutal)
        }

        if (Input.GetKeyDown(KeyCode.L)) // Debug add or remove health
        {
            GlobalVariables.health--;
        } else if (Input.GetKeyDown(KeyCode.P)) {
            GlobalVariables.health++;
        }
    }
}
