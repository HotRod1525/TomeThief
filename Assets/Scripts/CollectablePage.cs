using UnityEngine;

public class CollectiblePage : MonoBehaviour
{
    private bool collected = false;

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

                // Remove the collected page from the level.
                Destroy(gameObject);
            }
        }
    }
}