using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.asteroidTag))
        {
            // Play Sound,
            // TODO: check if player needs to be invurable.
            print("Shield Deactivated");
            gameObject.SetActive(false);
        }
    }
}
