using UnityEngine;

public class CameraLock : MonoBehaviour
{

    public Camera cam;
    public Vector3 newCameraPos;
    public float newOrthographicSize;
    public GameObject objectFocus; // IF there is something here, the camera will stay focused until this dies
    private bool existed;

    [Header("Trigger Box")]
    public Vector2 boxCenter; // Center of the trigger box
    public Vector2 boxSize = new Vector2(5f, 5f); // Width and height of the trigger box
    
    [Header("Player Reference")]
    public GameObject player; // Reference to the player
    
    [Header("Transition Settings")]
    public float transitionSpeed = 2f; // Speed of camera transitions
    
    private bool playerInBox = false;


    void Start()
    {
        if(objectFocus != null){
            existed = true;
        }
    }

    void Update()
    {
        
        // Check if player is within the trigger box
        bool wasInBox = playerInBox;
        playerInBox = IsPlayerInBox();
        
        // Handle camera locking logic
        if (existed && objectFocus != null)
        {
            if (playerInBox && !GlobalVariables.cameraLocked)
            {
                // Start camera lock transition
                GlobalVariables.cameraLocked = true;
            }
            
            if (GlobalVariables.cameraLocked)
            {
                // Smoothly transition camera to new position and size
                TransitionCamera();
                
                // Restrict player movement to box
                RestrictPlayerToBox();
            }
        }
        else
        {
            // objectFocus is destroyed or null
            existed = false;
            
            if (playerInBox != wasInBox && !playerInBox)
            {
                // Player left the box and objectFocus is destroyed
                GlobalVariables.cameraLocked = false;
            }
        }
    }
    
    private bool IsPlayerInBox()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 boxMin = boxCenter - boxSize * 0.5f;
        Vector2 boxMax = boxCenter + boxSize * 0.5f;
        
        return playerPos.x >= boxMin.x && playerPos.x <= boxMax.x && 
               playerPos.y >= boxMin.y && playerPos.y <= boxMax.y;
    }
    
    private void TransitionCamera()
    {
        // Smoothly move camera to new position
        cam.transform.position = Vector3.Lerp(cam.transform.position, newCameraPos, transitionSpeed * Time.deltaTime);
        
        // Smoothly change orthographic size
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newOrthographicSize, transitionSpeed * Time.deltaTime);
        
    }
    
    private void RestrictPlayerToBox()
    {
        Vector3 playerPos = player.transform.position;
        Vector2 boxMin = boxCenter - boxSize * 0.5f;
        Vector2 boxMax = boxCenter + boxSize * 0.5f;
        
        // Clamp player position to box boundaries
        float clampedX = Mathf.Clamp(playerPos.x, boxMin.x, boxMax.x);
        float clampedY = Mathf.Clamp(playerPos.y, boxMin.y, boxMax.y);
        
        // Only update position if it changed (to avoid unnecessary operations)
        if (playerPos.x != clampedX || playerPos.y != clampedY)
        {
            player.transform.position = new Vector3(clampedX, clampedY, playerPos.z);
        }
    }
    
    // Visualize the trigger box in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCenter, boxSize);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCenter, boxSize * 0.9f);
    }
}
