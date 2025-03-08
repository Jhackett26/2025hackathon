using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadTestSceneAfterDelay : MonoBehaviour
{
    public float delay = 3f; // Delay in seconds
    public string testSceneName = "TestScene"; // Name of the scene to load

    void Start()
    {
        Debug.Log("Current scene loaded. Waiting for " + delay + " seconds...");
        StartCoroutine(LoadTestSceneAfterDelayCoroutine());
    }

    private IEnumerator LoadTestSceneAfterDelayCoroutine()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        Debug.Log("Loading " + testSceneName + "...");
        SceneManager.LoadScene(testSceneName);
    }
}