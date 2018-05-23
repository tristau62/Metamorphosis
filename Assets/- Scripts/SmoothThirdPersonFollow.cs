using UnityEngine;
using System.Collections;
 
///<summary>
///Looks at a target
///</summary>
[AddComponentMenu("Camera-Control/Smooth Look At CS")]
public class SmoothThirdPersonFollow : MonoBehaviour {
	public Transform target;		//an Object to lock on to
	public float damping = 6.0f;	//to control the rotation 
	public bool smooth = true;
	public float minDistance = 10.0f;	//How far the target is from the camera
	public string property = "";
	public Vector3 RotationOffset = new Vector3(0, 0, 0);
 
	private Color color;
	private float alpha = 1.0f;
	private Transform _myTransform;
 
	void Awake() {
		_myTransform = transform;
	}
 
	// Use this for initialization
	void Start () {

	}
 
	// Update is called once per frame
	void Update () {
 		
	}
	
}