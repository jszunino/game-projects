using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Its okay");
                break;
            case "Obstacle":
                SceneManager.LoadScene(0);
                Debug.Log("-999 aura");
                break;
            case "Finish":
                LoadNextLevel();
                Debug.Log("+999 aura");
                break;
            default:
                ReloadLevel();
                Debug.Log("You're gay");
                break;
        }
    }

    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    private void LoadNextLevel() 
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
