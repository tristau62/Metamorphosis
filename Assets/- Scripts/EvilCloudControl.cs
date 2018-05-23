using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCloudControl : MonoBehaviour {
	public GameObject explosion;

    void OnTriggerEnter(Collider other)  {
        if (other.tag == "Player") {
        	Debug.Log("Test");
        	other.GetComponent<BirdGullController>().PlayCloudSFX();
            Instantiate(explosion, transform.position, transform.rotation);
            LifeManager.lives -= 1;
            Destroy(gameObject);
        }
    }
}
