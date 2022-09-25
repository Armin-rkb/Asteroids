using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.asteroidTag))
        {
            gameObject.SetActive(false);
        }
    }
}
