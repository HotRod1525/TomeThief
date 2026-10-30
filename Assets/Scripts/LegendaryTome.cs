using UnityEngine;

public class LegendaryTome : MonoBehaviour
{
    // Sound played when collecting the legendary tome.
    public AudioClip tomeSound;

    private bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check whether the player touched the tome.
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null && !collected)
        {
            // Find the EndingManager and trigger the ending.
            EndingManager endingManager = FindAnyObjectByType<EndingManager>();

            if (endingManager != null)
            {
                collected = true;

                // Play the tome collection sound.
                if (tomeSound != null && Camera.main != null)
                {
                    AudioSource.PlayClipAtPoint(
                        tomeSound,
                        Camera.main.transform.position,
                        0.3f
                    );
                }

                // Trigger the normal or special ending.
                endingManager.FinishGame(other.gameObject);
            }
        }
    }
}