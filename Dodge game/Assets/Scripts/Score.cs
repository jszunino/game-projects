using UnityEngine;

public class Score : MonoBehaviour
{
    int score = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Hit")
        {
            score++;
            Debug.Log("You're score is: " + score);
        }
    }
}
