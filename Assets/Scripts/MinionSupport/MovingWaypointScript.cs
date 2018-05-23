using UnityEngine;
using System.Collections;

public class MovingWaypointScript : MonoBehaviour
{

    private bool dirRight = true;
    public float speed = 2.0f;

    void Update()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= -16f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -24)
        {
            dirRight = true;
        }
    }
}
