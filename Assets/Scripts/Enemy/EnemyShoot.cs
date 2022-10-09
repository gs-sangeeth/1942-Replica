using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;

    public float timeBwShots = 2f;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBwShots)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0f;
        }
    }
}
