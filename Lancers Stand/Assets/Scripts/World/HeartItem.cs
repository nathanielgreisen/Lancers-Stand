using UnityEngine;

public class HeartItem : MonoBehaviour
{
    [Header("Animation Settings")]
    public float floatAmplitude = 0.5f; // How far up/down it moves
    public float floatSpeed = 2f; // Speed of up/down movement
    public float rotationSpeed = 90f; // Degrees per second for rotation
    
    private Vector3 startPosition;
    private float timeOffset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Store the initial position
        startPosition = transform.position;
        
        // Random time offset so multiple hearts don't move in sync
        timeOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        // Floating up and down animation
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed + timeOffset) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
        
        // Continuous horizontal rotation
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if player collected the heart
        if (other.CompareTag("Player"))
        {
            CollectHeart();
        }
    }
    
    void CollectHeart()
    {
        // Increase player's current health
        GlobalVariables.health += 1;
        
        // Destroy the heart item
        Destroy(gameObject);
    }
}
