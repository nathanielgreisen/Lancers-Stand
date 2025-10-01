using UnityEngine;

public class AutoFade : MonoBehaviour
{
    public float fadeDuration = 3f;

    // This entire script is pretty much solely for the use of the object that drops when
    // an enemy dies. It could be used elsewhere but wherever this script is applied, the object
    // will disappear and destroy itself in 'fadeDuration' seconds
    private void Start()
    {
        StartCoroutine(FadeOutAndDestroy());
    }

    private System.Collections.IEnumerator FadeOutAndDestroy()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color c = sr.color;

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration); // I love linear interpolation
            sr.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
        Destroy(gameObject);
    }
}
