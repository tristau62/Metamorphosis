using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdUI : MonoBehaviour {

	private bool playWindow;
	
	void Start() {
		Time.timeScale = 0;
		SimpleSmoothMouseLook.lockCursor = false;
		Cursor.lockState = CursorLockMode.None;
		playWindow = true;
	}
	
	void OnGUI() {
		if (playWindow) {
			GUILayout.Window(0, new Rect(680, 400, 500, 100), DoMyWindow, "Tutorial Window");
		}
	}
	
	void DoMyWindow(int windowID) {
		GUILayout.Label("Retrieve all of the rings to complete the level. Avoid black clouds or they will take a life. Regular clouds will give you speed. Use the mouse to direct the bird. White clouds give you a speed boost!");

		if (GUILayout.Button("Okay")) {
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			playWindow = false;
		}
	 
	}
}
