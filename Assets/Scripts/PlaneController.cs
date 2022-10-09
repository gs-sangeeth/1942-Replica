using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed = 10f;
    public float maxMoveSpeed = 10f;

    public float stopDuration = .5f;
    private float timer = 0f;

    public float rotationSpeed = 5f;

    private Vector2 input;

    public GameObject gotHit;

    public int maxHealth = 10;
    private int health;

    public GameObject bulletHitEffect;

    public GameObject[] deathEffects;
    public ParticleSystem heartBreakEffect;

    private bool dead = false;

    void Start()
    {
        AudioManager.instance.Play("theme");
        rb = GetComponent<Rigidbody>();

        health = maxHealth;
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * 3) * moveSpeed;
    }

    private void FixedUpdate()
    {

        rb.AddForce(input);

        //Speed Limit
        if (rb.velocity.magnitude >= maxMoveSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxMoveSpeed;
        }

        // Stop movement by lerping??
        if (input.magnitude == 0 && rb.velocity.magnitude >= 0f)
        {
            timer += Time.deltaTime;
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, timer / stopDuration);
            if (rb.velocity.magnitude <= .002f)
            {
                rb.velocity = Vector2.zero;
            }
        }

        if (rb.velocity == Vector3.zero)
        {
            timer = 0;
        }

        //Tilt
        rb.rotation = Quaternion.Euler(0.0f, rb.velocity.x * -rotationSpeed + 180, 0.0f);

        // Health
        if (health <= 0)
        {
            if (!dead)
            {
                AudioManager.instance.Play("playerDeath");
                foreach (GameObject deathEffect in deathEffects)
                {
                    var effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
                    effect.transform.parent = transform;
                }
                Invoke(nameof(PlayHeartEffect), 1f);
                dead = true;
                Invoke(nameof(Die), 2.5f);
            }
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PlayHeartEffect()
    {
        AudioManager.instance.Play("death");
        heartBreakEffect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(gotHit, transform.position, Quaternion.identity);
            other.GetComponent<Enemy>().Destroy();
            AudioManager.instance.Play("playerHurt");

            health -= 3;
        }

        if (other.CompareTag("EnemyBullet"))
        {
            Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
            AudioManager.instance.Play("playerHurt");

            health--;
        }
    }
}
