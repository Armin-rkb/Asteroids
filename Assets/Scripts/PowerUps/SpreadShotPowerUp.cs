using System;
using UnityEngine;

public class SpreadShotPowerUp : MonoBehaviour
{
    public static event Action OnSpreadShotCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySound(SoundClip.PowerUp);
        OnSpreadShotCollected?.Invoke();
        Destroy(gameObject);
    }
}
