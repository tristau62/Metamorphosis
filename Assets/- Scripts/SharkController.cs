using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_Controller : MonoBehaviour {
	public float speed;
	private new Rigidbody rigidbody;
	private float horiz;
	private float vert;

    public Vector3 moveDirection;

    private float currentDashTime;

    // Use this for initialization
    void Start () {
		speed = 5.0f;
		rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		vert = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("KeyCode.Space"))
        {
            rigidbody.velocity = rigidbody.transform.forward * 20;
        }
        
    }
}

