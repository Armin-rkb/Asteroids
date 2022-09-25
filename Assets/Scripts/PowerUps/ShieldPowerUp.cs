using System;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public static event Action OnShieldCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySound(SoundClip.PowerUp);
        OnShieldCollected?.Invoke();
        Destroy(gameObject);
    }
}
