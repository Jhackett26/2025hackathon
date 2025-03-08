using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    public float speed = 1.0f; // Speed of the crane movement
    private bool moveRight = true; // Direction of movement
    public playerControler playerControler; // Reference to the player controller

    void Start()
    {
        // Assign playerControler if not set in the Inspector
        if (playerControler == null)
        {
            if (playerControler == null)
            {
                Debug.LogError("playerControler not found in the scene!");
            }
        }
    }

    void Update()
    {
        // Move the crane left and right within bounds
        if (transform.position.x > 5f)
        {
            moveRight = false;
        }
        else if (transform.position.x < 0f)
        {
            moveRight = true;
        }

        // Move the crane based on direction
        if (moveRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (playerControler == null)
        {
            Debug.LogError("playerControler is not assigned!");
            return;
        }

        // Check if the collider is the left hand
        if (other.name =="left hand")
        {
            playerControler.lCanGrab = true;
            //Debug.Log("Left hand detected");
            if (playerControler.leftLock)
            {
                MoveHand(playerControler.right_hand.transform);
                MoveHand(playerControler.left_hand.transform);
            }
        }
        // Check if the collider is the right hand
        else if (other.name == "right hand")
        {
            playerControler.rCanGrab = true;
            //Debug.Log("Right hand detected");
            if (playerControler.rightLock)
            {
                MoveHand(playerControler.right_hand.transform);
                MoveHand(playerControler.left_hand.transform);
            }
        }
    }

    private void MoveHand(Transform hand)
    {
        // Move the hand based on the crane's direction
        if (moveRight)
        {
            hand.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            hand.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (playerControler != null)
        {
            playerControler.lCanGrab = false;
            playerControler.rCanGrab = false;
        }
        else
        {
            Debug.LogError("playerControler is not assigned!");
        }
    }
}