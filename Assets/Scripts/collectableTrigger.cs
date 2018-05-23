using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectableTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		print ("yes");
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene (0);
			print ("Loading Shark Level");
		}
	}
}
