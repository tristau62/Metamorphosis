using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionController : MonoBehaviour {
    public GameObject remains;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bear")
        {
            Instantiate(remains, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
