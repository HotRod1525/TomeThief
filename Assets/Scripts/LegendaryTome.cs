using UnityEngine;

public class LegendaryTome : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check whether the player touched the tome.
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            // Find the EndingManager and trigger the ending.
            EndingManager endingManager = FindAnyObjectByType<EndingManager>();

            if (endingManager != null)
            {
                endingManager.FinishGame(other.gameObject);
            }
        }
    }
}