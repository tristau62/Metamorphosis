using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUI : MonoBehaviour {

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
		GUILayout.Label ("Collect all 12 Fish, and then shoot for the sky! Use the mouse to direct the shark. Holding space gives you a speed boost!");

		if (GUILayout.Button ("Okay")) {
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
			playWindow = false;
		}
	}
}
