using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
	public float speed;
	private Rigidbody rigidbody;
	private float horiz;
	private float vert;

	// Use this for initialization
	void Start () {
		speed = 4.0f;
		rigidbody = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
		vert = Input.GetAxis("Vertical");

		//speed += vert;

		if (speed < 0) {
			speed = 0;
		} else if (speed > 12) {
			speed = 12;
		}
		
		rigidbody.velocity = transform.forward * speed;
	}
}
