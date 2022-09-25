using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosionEffect;
    public GameObject gameOverUI;
    [SerializeField] private GameObject shieldPowerUp;
    [SerializeField] private GameObject spreadShotPowerUp;
    [SerializeField] private GameObject rainbowPowerUp;

    public int score { get; private set; }
    public Text scoreText;

    public int lives { get; private set; }
    public Text livesText;

    private bool firstSpawn = true;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.GetKeyDown(KeyCode.Return)) {
            NewGame();
        }
    }

    public void NewGame()
    {
        Asteroid[] asteroids = FindObjectsOfType<Asteroid>();

        for (int i = 0; i < asteroids.Length; i++) {
            Destroy(asteroids[i].gameObject);
        }

        gameOverUI.SetActive(false);

        SetScore(0);
        SetLives(3);
        Respawn();
        firstSpawn = false;
    }

    public void Respawn()
    {
        if (!firstSpawn)
        {
            SoundManager.instance.PlaySound(SoundClip.Respawn);
        }
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        explosionEffect.transform.position = asteroid.transform.position;
        explosionEffect.Play();

        if (asteroid.size < 0.7f) {
            SetScore(score + 100); // small asteroid
        } else if (asteroid.size < 1.4f) {
            SetScore(score + 50); // medium asteroid
        } else {
            SetScore(score + 25); // large asteroid
        }

        // 5% chance to spawn an powerup.
        if (Random.value > 0.95)
        {
            SpawnPowerUp(asteroid.transform.position);
        }
    }

    private void SpawnPowerUp(Vector2 spawnPos)
    {
        // Spreadshot is the default powerup to spawn.
        GameObject powerUp = spreadShotPowerUp;

        // 30% chance to change spreadshot to rainbow or shield
        if (Random.value > 0.7)
        {
            powerUp = shieldPowerUp;

            if (Random.value > 0.5)
            {
                powerUp = rainbowPowerUp;
            }
        }

        Instantiate(powerUp, spawnPos, Quaternion.identity);
    }

    public void PlayerDeath(Player player)
    {
        explosionEffect.transform.position = player.transform.position;
        explosionEffect.Play();

        SetLives(lives - 1);

        if (lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), player.respawnDelay);
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }

}
