using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrenght = 100f;
    [SerializeField] float rotationStrenght = 100f;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] AudioClip mainEngine;
    AudioSource audioSource;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }
    private void FixedUpdate()
    {
        processThrust();
        processRotation();
    }

    private void processThrust()
    {
        if (thrust.IsPressed())
        {
            ThrustEffects();
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
    }

    private void ThrustEffects()
    {
        rb.AddRelativeForce(Vector3.up * thrustStrenght * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
            mainEngineParticles.Play();
        }
    }

    private void processRotation()
    {
        RotateEffects();
    }

    private void RotateEffects()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrenght);
            rightEngineParticles.Play();
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrenght);
            leftEngineParticles.Play();
        }
        else
        {
            leftEngineParticles.Stop();
            rightEngineParticles.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
