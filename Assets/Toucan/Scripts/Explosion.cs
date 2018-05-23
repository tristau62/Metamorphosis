using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Kill>())
        {
            collision.gameObject.GetComponent<Kill>().Execute();
        }
    }
}
