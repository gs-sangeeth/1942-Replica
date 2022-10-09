using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int maxHealth = 1;
    protected int health;

    public GameObject deathEffect;
    public GameObject damageEffect;

    private void Awake()
    {
        gameObject.tag = "Enemy";
        health = maxHealth;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        if (health <= 0)
        {
            Destroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (gameObject.GetComponent<Renderer>().isVisible)
            {
                Damage();
            }
        }
    }

    public void Destroy()
    {
        AudioManager.instance.Play("enemyDeath");
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

    private void Damage()
    {
        AudioManager.instance.Play("enemyDamage");
        Instantiate(damageEffect, transform.position, Quaternion.identity);
        health--;
    }
}
