using UnityEngine;

public class AutoFade : MonoBehaviour
{
    public float fadeDuration = 3f;

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
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            sr.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
        Destroy(gameObject);
    }
}
