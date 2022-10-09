using UnityEngine;

public class NewTerrainSpawner : MonoBehaviour
{
    public GameObject nextTerrain;

    public Transform terrainSpawnPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TD"))
        {
            Instantiate(nextTerrain, terrainSpawnPos.position, Quaternion.identity);
        }
    }
}
