using UnityEngine;

public class Terrain : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }
}
