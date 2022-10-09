using UnityEngine;

public class GunPoint : MonoBehaviour
{
    public GameObject bullet;

    public float timeBwBulletSpawns = .2f;
    private float timer;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && timer <= 0)
        {
            foreach (Transform pos in transform)
            {
                AudioManager.instance.Play("shoot");
                Instantiate(bullet, pos.position, Quaternion.identity);
            }
            timer = timeBwBulletSpawns;
        }

        timer -= Time.deltaTime;
    }
}
