using UnityEngine;

public class Lock2D: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector2(0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
