using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]float xValue = 0f;
    [SerializeField]float yValue = 0.5f;
    [SerializeField]float zValue = 0f;
    void Update()
    {
        transform.Rotate(xValue, yValue, zValue);
    }
}
