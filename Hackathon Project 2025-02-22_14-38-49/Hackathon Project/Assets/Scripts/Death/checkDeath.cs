using UnityEngine;
using UnityEngine.SceneManagement;

public class checkDeath : MonoBehaviour
{
    public string deathSceneName = "Death";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -2)
        {
            SceneManager.LoadScene(deathSceneName);
        }
    }
}
