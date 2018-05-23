using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    public float speed;
    public GameObject explision;

	// Update is called once per frame
	void Update () {
        transform.localPosition += transform.forward * speed;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Respawn")
        {
            Destroy(gameObject);
            Instantiate(explision, transform.position, Quaternion.identity);
        }
    }
}
