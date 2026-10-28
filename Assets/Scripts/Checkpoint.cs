using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Only activate when the player touches this checkpoint.
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null && !activated)
        {
            activated = true;

            // Save a safe respawn position just above the checkpoint.
            Vector3 newRespawnPosition = transform.position + Vector3.up * 1.2f;

            playerHealth.SetCheckpoint(newRespawnPosition);

            // Change color to show that the checkpoint is active.
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}
