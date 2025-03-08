using UnityEngine;

public class playerControler : MonoBehaviour
{
    public GameObject left_hand;
    public GameObject right_hand;
    public float speed = 15f;
    public float sensitivity = 1.0f;
    public bool rightLock = false;
    public bool leftLock = true;
    public bool lCanGrab;
    public bool rCanGrab;
    public float grabbedX;
    public float grabbedY;
    public bool isFalling = false;
    float timer = 0;
    public bool callTimer = false;

    public Rigidbody leftHandRigidbody;
    public Rigidbody rightHandRigidbody;

    void Start()
    {
        // Get the Rigidbody components from the left and right hands
        leftHandRigidbody = left_hand.GetComponent<Rigidbody>();
        rightHandRigidbody = right_hand.GetComponent<Rigidbody>();

        if (leftHandRigidbody == null || rightHandRigidbody == null)
        {
            Debug.LogError("One or both hands are missing a Rigidbody component!");
        }
    }

    void Update()
    {
        left_hand.transform.position = new Vector3(left_hand.transform.position.x, left_hand.transform.position.y, .1f);
        right_hand.transform.position = new Vector3(right_hand.transform.position.x, right_hand.transform.position.y, .1f);
        left_hand.transform.rotation = Quaternion.Euler(0, 0, 0);
        right_hand.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (!leftLock)
        {
            leftControl();
        }
        if (!rightLock)
        {
            rightControl();
        }
        if ((Input.GetKey(KeyCode.Mouse0) && !rCanGrab))
        {
            isFalling = true;
            leftLock = false;
            rightLock = true;
        }
        if (Input.GetKey(KeyCode.Space) && !lCanGrab)
        {
            isFalling = true;
            leftLock = true;
            rightLock = false;
        }
        if (!isFalling)
        {
            leftHandRigidbody.isKinematic = true;
            rightHandRigidbody.isKinematic = true;
        }
        else
        {
            leftHandRigidbody.isKinematic = false;
            rightHandRigidbody.isKinematic = false;
        }
        if (callTimer)
        {
            launchRight(1, 70f);
        }
    }

    void leftControl()
    {
        if (Input.GetKey(KeyCode.W) && left_hand.transform.position.y - right_hand.transform.position.y <= .75)
        {
            left_hand.transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && right_hand.transform.position.y - left_hand.transform.position.y <= .75)
        {
            left_hand.transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && Mathf.Abs(right_hand.transform.position.x - left_hand.transform.position.x) <= 1.5)
        {
            left_hand.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && left_hand.transform.position.x < right_hand.transform.position.x - .2)
        {
            left_hand.transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && lCanGrab)
        {
            leftLock = true;
            rightLock = false;
            isFalling = false;
            //left_hand.transform.position = new Vector2(grabbedX, grabbedY);
        }
    }

    void rightControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movement = new Vector3(mouseX, mouseY, 0);
        right_hand.transform.position += movement;
        right_hand.transform.position = new Vector3(
            Mathf.Clamp(right_hand.transform.position.x, left_hand.transform.position.x + .2f, left_hand.transform.position.x + 1.5f),
            Mathf.Clamp(right_hand.transform.position.y, left_hand.transform.position.y - .75f, left_hand.transform.position.y + .75f),
            right_hand.transform.position.z
        );

        if (Input.GetKey(KeyCode.Mouse0) && rCanGrab)
        {
            rightLock = true;
            leftLock = false;
            isFalling = false;
            //right_hand.transform.position = new Vector2(grabbedX, grabbedY);
        }
    }
    void launchRight(int duration, float speed)
    {
        timer += Time.deltaTime;
        // Check if the timer has reached the duration
        if (timer >= duration)
        {
            timer = 0;
            callTimer = false;
        }
        else
        {
            left_hand.transform.position += Vector3.right * speed * Time.deltaTime;
            right_hand.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}