using UnityEngine;

public enum SoundClip
{
    Explosion_Big,
    Explosion_Small,
    Laser_Shoot,
    PowerUp,
    Respawn
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Create instance!");
        }
        else
        {
            instance = this;
        }
    }

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip explosionBig;
    [SerializeField] private AudioClip explosionSmall;
    [SerializeField] private AudioClip LaserShoot;
    [SerializeField] private AudioClip PowerUp;
    [SerializeField] private AudioClip Respawn;

    public void PlaySound(SoundClip soundClip)
    {
        switch (soundClip)
        {
            case SoundClip.Explosion_Big:
                audioSource.clip = explosionBig;
                break;
            case SoundClip.Explosion_Small:
                audioSource.clip = explosionSmall;
                break;
            case SoundClip.Laser_Shoot:
                audioSource.clip = LaserShoot;
                break;
            case SoundClip.PowerUp:
                audioSource.clip = PowerUp;
                break;
            case SoundClip.Respawn:
                audioSource.clip = Respawn;
                break;
            default:
                Debug.LogWarning("Invalid soundclip");
                break;
        }

        audioSource.PlayOneShot(audioSource.clip);
    }
}
