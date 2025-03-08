using UnityEngine;

public class grabableCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public playerControler playerControler;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (playerControler == null)
        {
            Debug.LogError("playerControler is not assigned!");
            return;
        }

        if (other.name == "left hand")
        {
            playerControler.lCanGrab = true;
            playerControler.grabbedX = transform.position.x;
            playerControler.grabbedY = transform.position.y;
        }
        else if (other.name == "right hand")
        {
            playerControler.rCanGrab = true;
            playerControler.grabbedX = transform.position.x;
            playerControler.grabbedY = transform.position.y;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.name == "left hand")
        {
            playerControler.lCanGrab = false;
        }
        else if (other.name == "right hand")
        {
            playerControler.rCanGrab = false;
        }
    }
}
