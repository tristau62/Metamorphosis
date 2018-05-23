using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour {
    public GameObject explosion;

    void OnTriggerEnter(Collider other)  {
        if (other.tag == "Player") {
        	Debug.Log("Test");
        	other.GetComponent<BirdGullController>().PlayCloudSFX();
            Instantiate(explosion, transform.position, transform.rotation);
            other.gameObject.GetComponent<BirdGullController>().speed += 1;
            Destroy(gameObject);
        }
    }
}
