using UnityEngine;

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
                Debug.Log("-999 aura");
                break;
            case "Finish":
                Debug.Log("+999 aura");
                break;
            default:
                Debug.Log("You're gay");
                break;
        }
    }
}
