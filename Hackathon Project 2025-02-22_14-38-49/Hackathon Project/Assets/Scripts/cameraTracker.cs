using UnityEngine;

public class cameraTracker : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public Vector3 offset = new Vector3(0, 0, 0); // Camera offset from the player
    public float smoothTime = 0.1f; // Time to reach the target
    private Vector3 velocity = Vector3.zero; // Used internally by SmoothDamp

    void LateUpdate()
    {
        // Target position is the player's position plus the offset
        Vector3 targetPosition = player.transform.position + offset;

        // Smoothly move the camera toward the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -3);
    }
}
