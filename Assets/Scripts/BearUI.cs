using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearUI : MonoBehaviour {

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
		GUILayout.Label ("Get to the end of the island and find the goal without becoming wolf food.  Use W-A-S-D to move.");

		if (GUILayout.Button ("Okay")) {
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			playWindow = false;
		}
	}
}
