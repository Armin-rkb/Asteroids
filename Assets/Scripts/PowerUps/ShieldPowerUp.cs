using System;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public static event Action OnShieldCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Play Sound
        OnShieldCollected?.Invoke();
        Destroy(gameObject);
    }
}
