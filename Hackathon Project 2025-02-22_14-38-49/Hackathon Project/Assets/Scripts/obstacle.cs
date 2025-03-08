using UnityEngine;

public class obstacle : MonoBehaviour
{
    public playerControler playerControler; // Reference to the playerControler script
    public float fastSpeed = 15f; // Speed when moving quickly to the right
    public float slowSpeed = .5f;  // Speed when moving slowly back to the left
    public float throwForce = 500f; // Force applied to objects when hit during fast movement

    private bool isMovingFast = true;
    private bool hasHitObject = false;

    void Update()
    {
        if (isMovingFast)
        {
            // Move quickly to the right
            transform.Translate(Vector3.right * fastSpeed * Time.deltaTime);

            // Check if the object has reached a certain point (e.g., x = 10)
            if (transform.position.x >= 0f)
            {
                isMovingFast = false;
            }
        }
        else
        {
            // Move slowly back to the left
            transform.Translate(Vector3.left * slowSpeed * Time.deltaTime);

            // Check if the object has returned to the starting point (e.g., x = 0)
            if (transform.position.x <= -5f)
            {
                isMovingFast = true;
                hasHitObject = false; // Reset the hit flag
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "left hand" || other.name == "right hand")
        { 
            if (isMovingFast && !hasHitObject)
            {
                Debug.Log("hit");
                playerControler.leftHandRigidbody.isKinematic = false;
                playerControler.leftHandRigidbody.isKinematic = false;
                playerControler.isFalling = true;
                playerControler.callTimer = true;
                hasHitObject = true; // Prevent multiple hits
                }
            }
        }
    }