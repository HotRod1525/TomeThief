using UnityEngine;

public class CollectiblePage : MonoBehaviour
{
    private bool collected = false;

    // Sound played when collecting a page.
    public AudioClip collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check whether the player touched this page.
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null && !collected)
        {
            PageManager pageManager = FindAnyObjectByType<PageManager>();

            if (pageManager != null)
            {
                collected = true;

                // Increase the page counter.
                pageManager.CollectPage();

                // Play the collection sound before removing the page.
                if (collectSound != null)
                {
                    AudioSource.PlayClipAtPoint(
                        collectSound,
                        Camera.main.transform.position,
                        0.3f
                    );
                }

                // Remove the collected page from the level.
                Destroy(gameObject);
            }
        }
    }
}