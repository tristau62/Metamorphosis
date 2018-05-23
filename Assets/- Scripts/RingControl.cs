using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingControl : MonoBehaviour {
    public GameObject explosion;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)  {
        if (other.tag == "Player") {
        	other.GetComponent<BirdGullController>().PlayRingSFX();
        	
        	RingManager.score += 1;
            audioSource.Play();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }
}
