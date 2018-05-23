using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfKnock : MonoBehaviour {
	Vector3 impact = Vector3.zero;
	private CharacterController character;
	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		character.Move(impact * Time.deltaTime);
		impact = Vector3.Lerp(impact, Vector3.zero, 4*Time.deltaTime);
	}

	public void BearImpact(Vector3 dir, float force){
		dir.Normalize();
		if (dir.y < 0) dir.y = -dir.y; 
		impact += dir.normalized * force;


	}
}