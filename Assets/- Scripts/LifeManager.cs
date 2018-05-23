using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {
	private int maxLives;

    public static int lives;

    public GameObject player;

    private Text text;
    private bool playWindow;

    void Awake () {
    	maxLives = 3;
        text = GetComponent <Text> ();
        lives = maxLives;
        playWindow = false;
    }


    void Update () {
    	if (lives <= 0) {
        	lives = 0;
        	Time.timeScale = 0;
        	Cursor.lockState = CursorLockMode.None;
        	player.GetComponent<SimpleSmoothMouseLook>().enabled = false;
        	playWindow = true;
        }

        text.text = "Lives: " + lives + " / " + maxLives;
    }

    void OnGUI() {
		if (playWindow) {
			GUILayout.Window(0, new Rect(680, 400, 500, 100), DoMyWindow, "Game Over");
		}
	}
	
	void DoMyWindow(int windowID) {

		//GUILayout.Label("Game Over!");

		if (GUILayout.Button("Restart")) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	 
	}
}
