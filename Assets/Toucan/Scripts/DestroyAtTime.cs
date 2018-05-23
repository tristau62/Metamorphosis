using UnityEngine;
using System.Collections;

public class DestroyAtTime : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, time);
	}

}
