using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // Number of lives the player starts with.
    public int maxLives = 3;
    public GameObject gameOverCanvas;
    public TMP_Text livesText;

    // Sound played when the player loses their final life.
    public AudioClip deathSound;

    private int currentLives;
    private Vector3 respawnPosition;
    private Rigidbody2D rb;

    void Start()
    {
        currentLives = maxLives;
        respawnPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();

        Debug.Log("Lives: " + currentLives);

        UpdateLivesText();
    }

    void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    public void TakeDamage()
    {
        currentLives--;

        Debug.Log("Lives remaining: " + currentLives);

        UpdateLivesText();

        // Play the sound whenever the player loses a life.
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(
                deathSound,
                Camera.main.transform.position,
                0.8f
            );
        }

        if (currentLives > 0)
        {
            Respawn();
        }
        else
        {
            GameOver();
        }
    }

    public void SetCheckpoint(Vector3 newPosition)
    {
        // Update the position where the player will respawn.
        respawnPosition = newPosition;

        Debug.Log("Checkpoint activated!");
    }

    void Respawn()
    {
        // Stop the player's movement before respawning.
        rb.linearVelocity = Vector2.zero;

        // Return the player to their checkpoint.
        transform.position = respawnPosition;
    }

    void GameOver()
    {
        Debug.Log("GAME OVER!");

        // Stop the player from moving.
        GetComponent<PlayerMovement>().enabled = false;

        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;

        // Display the Game Over screen.
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }
}