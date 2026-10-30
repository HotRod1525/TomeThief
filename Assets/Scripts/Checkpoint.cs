using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    // Sound played when the checkpoint is activated.
    public AudioClip checkpointSound;

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
            GetComponent<SpriteRenderer>().color = Color.cyan;

            // Play the checkpoint activation sound.
            if (checkpointSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    checkpointSound,
                    Camera.main.transform.position,
                    0.3f
                );
            }
        }
    }
}