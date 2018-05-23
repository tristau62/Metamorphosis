using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
