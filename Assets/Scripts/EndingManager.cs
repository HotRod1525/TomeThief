using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject normalEndingCanvas;
    public GameObject specialEndingCanvas;
    public PageManager pageManager;

    private bool gameFinished = false;

    public void FinishGame(GameObject player)
    {
        // Prevent the game from ending more than once.
        if (gameFinished)
            return;

        gameFinished = true;

        // Stop player movement.
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        if (movement != null)
            movement.enabled = false;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        // Determine which ending the player receives.
        if (pageManager.HasAllPages())
        {
            specialEndingCanvas.SetActive(true);
            Debug.Log("Special ending!");
        }
        else
        {
            normalEndingCanvas.SetActive(true);
            Debug.Log("Normal ending!");
        }
    }
}