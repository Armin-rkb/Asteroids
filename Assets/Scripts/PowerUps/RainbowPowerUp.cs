using System;
using UnityEngine;

public class RainbowPowerUp : MonoBehaviour
{
    public static event Action OnRainbowCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySound(SoundClip.PowerUp);
        OnRainbowCollected?.Invoke();
        Destroy(gameObject);
    }
}
