using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Material defaultMat;
    public Material rainbowMat;
    public Bullet bulletPrefab;
    public ScreenShake screenShake;
    public GameObject shield;
    public GameObject[] WeaponNozzles;

    public float thrustSpeed = 1f;
    public bool thrusting { get; private set; }

    public float turnDirection { get; private set; } = 0f;
    public float rotationSpeed = 0.1f;

    public float respawnDelay = 3f;
    public float respawnInvulnerability = 3f;
    public float rainbowInvulnerability = 10f;
    public float rainbowMultiplier = 1;

    private bool isShielded = false;
    private int weaponCount = 1;

    private IEnumerator blinkCoroutine;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // Turn off collisions for a few seconds after spawning to ensure the
        // player has enough time to safely move away from asteroids
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        blinkCoroutine = Blink();
        StartCoroutine(blinkCoroutine);
        Invoke(nameof(TurnOnCollisions), respawnInvulnerability);
        
        // Subscribe to events.
        ShieldPowerUp.OnShieldCollected += ActivateShield;
        SpreadShotPowerUp.OnSpreadShotCollected += AddWeapon;
        RainbowPowerUp.OnRainbowCollected += SetInvurnable;
    }

    private void OnDisable()
    {
        // Remove from all events.
        ShieldPowerUp.OnShieldCollected -= ActivateShield;
        SpreadShotPowerUp.OnSpreadShotCollected -= AddWeapon;
        RainbowPowerUp.OnRainbowCollected -= SetInvurnable;
    }

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1f;
        } else {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (thrusting) {
            rigidbody.AddForce(transform.up * (thrustSpeed * rainbowMultiplier));
        }

        if (turnDirection != 0f) {
            rigidbody.AddTorque((rotationSpeed * rainbowMultiplier) * turnDirection);
        }
    }

    private void Shoot()
    {
        screenShake.StartShakeCoroutine(0.03f, 0.05f);
        SoundManager.instance.PlaySound(SoundClip.Laser_Shoot);

        for (int i = 0; i < weaponCount; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, WeaponNozzles[i].transform.position, WeaponNozzles[i].transform.rotation);
            bullet.Project(WeaponNozzles[i].transform.rotation * Vector2.up);
        }
    }

    private void TurnOnCollisions()
    {
        StopCoroutine(blinkCoroutine);
        rainbowMultiplier = 1;
        spriteRenderer.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private IEnumerator Blink()
    {
        while(true)
        {
            spriteRenderer.enabled = spriteRenderer.enabled ? false : true;
            yield return new WaitForSeconds(.05f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.asteroidTag))
        {
            if (isShielded)
            {
                isShielded = false;
                return;
            }

            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0f;
            gameObject.SetActive(false);

            weaponCount = 1;
            screenShake.StartShakeCoroutine(0.5f, 0.8f);
            SoundManager.instance.PlaySound(SoundClip.Explosion_Big);
            FindObjectOfType<GameManager>().PlayerDeath(this);
        }
    }

    private void ActivateShield()
    {
        isShielded = true;
        shield.SetActive(true);
    }
    
    private void AddWeapon()
    {
        if (weaponCount != WeaponNozzles.Length)
        {
            weaponCount++;
        }
    }
    
    private void SetInvurnable()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        spriteRenderer.material = rainbowMat;
        rainbowMultiplier = 2;

        Invoke(nameof(SetDefaultMaterial), rainbowInvulnerability);
        Invoke(nameof(TurnOnCollisions), rainbowInvulnerability);
    }

    private void SetDefaultMaterial()
    {
        spriteRenderer.material = defaultMat;
    }
}
