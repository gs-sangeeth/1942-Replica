using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    GameObject plane;

    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Player");   
    }

    void Update()
    {
        var newPos = plane.transform.position;
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}
