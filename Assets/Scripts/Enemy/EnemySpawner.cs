using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform negativePos, positivePos;

    public GameObject[] enemies;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, 1f);
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPos = Vector3.Lerp(negativePos.position, positivePos.position, Random.Range(0f, 1f));
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.Euler(90f, 180f, 0f));
    }
}
