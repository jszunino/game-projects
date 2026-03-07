using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField]float dropTime = 3.0f;

    MeshRenderer meshRenderer;
    Rigidbody rb;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Time.time >= dropTime)
        {
            rb.useGravity = true;
            meshRenderer.enabled = true;
        }
    }
}
