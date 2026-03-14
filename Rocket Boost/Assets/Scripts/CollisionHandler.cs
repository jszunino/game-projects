using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float DelayTime = 2f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip explosionSFX;
    AudioSource audioSource;
    bool isControllable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (!isControllable){return;}

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Its okay");
                break;
            case "Finish":
                StartSuccesSequence();
                Debug.Log("+999 aura");
                break;
            default:
                StartCrashSequence();
                Debug.Log("You're gay");
                break;
        }
    }

    void StartSuccesSequence()
    {
        isControllable = false;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", DelayTime);
        audioSource.PlayOneShot(successSFX);
    }

    void StartCrashSequence()
    {
        isControllable = false;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", DelayTime);
        audioSource.PlayOneShot(explosionSFX);
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
