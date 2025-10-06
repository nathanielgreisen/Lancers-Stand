using UnityEngine;

public class voidCollider : MonoBehaviour
{
    public Vector2 returnLocation;
    public GameObject player;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // So it doesnt appear if a random enemy is in there
        {
            GlobalVariables.health--;

            player.transform.position = returnLocation;
        }
    }
}
