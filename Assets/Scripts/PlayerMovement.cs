using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement settings
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    // Jump sound
    public AudioClip jumpSound;
    private AudioSource audioSource;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    void Start()
    {
        // Get the components attached to the player
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Move left or right using A and D
        float horizontal = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }

        // Face the direction the player is moving
        if (horizontal < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0f)
        {
            spriteRenderer.flipX = false;
        }

        // Preserve vertical velocity while moving horizontally
        rb.linearVelocity = new Vector2(
            horizontal * moveSpeed,
            rb.linearVelocity.y
        );

        // Jump only when touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );

            isGrounded = false;

            // Play the jump sound
            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Detect whether the player is standing on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Lose a life when touching a hazard
        if (other.CompareTag("Hazard"))
        {
            GetComponent<PlayerHealth>().TakeDamage();
        }
    }
}