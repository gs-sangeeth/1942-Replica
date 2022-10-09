using UnityEngine;

public class EnemyCurvePath : Enemy
{
    public float xOffset = 6f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;    
    }

    void Update()
    {
        transform.position += new Vector3(Mathf.Sin(Time.time * 3f) * xOffset, -base.speed, 0.0f) * Time.deltaTime;

        if (base.health <= 0)
        {
            Destroy();
        }
    }
}
