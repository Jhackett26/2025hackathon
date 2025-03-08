using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject hat;
    public GameObject playerHat;
    public Material texture;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "left hand" || other.name == "right hand")
        {
            hat.transform.position += Vector3.forward;
            playerHat.GetComponent<MeshRenderer>().material = texture;
        }
    }
}
