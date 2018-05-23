using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene(0);
		GameManager.score = 0;
	}
		

}
