using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    private float fixedX;
    private float fixedZ;

    void Start()
    {
        // Remember the camera's original horizontal position and depth.
        fixedX = transform.position.x;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        // Follow the player's vertical position smoothly.
        float newY = Mathf.Lerp(
            transform.position.y,
            player.position.y,
            smoothSpeed * Time.deltaTime
        );

        // Keep the camera's X and Z positions unchanged.
        transform.position = new Vector3(fixedX, newY, fixedZ);
    }
}