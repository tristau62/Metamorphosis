using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGullController : MonoBehaviour {
	public float speed;
	private Rigidbody rigidbody;
	private float horiz;
	private float vert;
	
	public Vector3 RotationOffset;
	public float forwardOffset;
	public float upwardOffset;

	public AudioSource ringAudio;
	public AudioSource cloudAudio;

	// Use this for initialization
	void Start () {
		speed = 4.0f;
		rigidbody = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		vert = Input.GetAxis("Vertical");

		//speed += vert;

		if (speed < 0) {
			speed = 0;
		} else if (speed > 12) {
			speed = 12;
		}
		
		rigidbody.velocity = transform.forward * speed;

		Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
			transform.position - transform.forward * forwardOffset + transform.up * upwardOffset, speed * Time.deltaTime);
 		
 		Quaternion RotationTarget = transform.rotation * Quaternion.Euler(RotationOffset);
 		Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, RotationTarget, 4f * Time.deltaTime);
	}

    public void PlayRingSFX() {
    	ringAudio.Play();
    }

    public void PlayCloudSFX() {
    	cloudAudio.Play();
    }
}
