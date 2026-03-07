using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 150f;
    void Start()
    {
        methodTest();
    }

    void Update()
    {
        playerMovement();
    }

    void methodTest()
    {
        Debug.Log("Does it work?");
    }

    void playerMovement()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue, yValue, zValue);
    }
}
