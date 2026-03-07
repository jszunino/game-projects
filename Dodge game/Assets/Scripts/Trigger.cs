using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            projectile.SetActive(true);
        }
    }
}
