using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 64.3f);
    }

    void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector2.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BD"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Bullet") || other.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}
