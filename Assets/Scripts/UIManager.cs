using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Rect windowRect = new Rect(0, 0, 0, 0);
    public bool trig = true;
	public bool trig2 = true;
    void Start()
    {
        windowRect = new Rect(680, 400, 500, 100);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnGUI()
    {
		if (trig && GameManager.score < 1) {
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow, "Metamorphosis");
		} else if (trig2 && GameManager.score == 3) {
			windowRect = GUILayout.Window (0, windowRect, DoMyWindow2, "WINNER"); 
		}
		else
        {
            Time.timeScale = 1;
        }
    }

    void DoMyWindow(int windowID)
    {
		GUILayout.Label("You've awoken in a mystical Mayan temple and you're trapped! The only way to escape and return home is by using the temple's magic to become one with nature and get through each level as a unique animal. Walk through a door to begin. Use W-A-S-D to move.");

        if (GUILayout.Button("Okay"))
        {
            Time.timeScale = 1;
            trig = false;
        }

    }
	void DoMyWindow2(int windowID)
	{
		GUILayout.Label ("You have defeated all three animal challenges and escaped the temple");

		if (GUILayout.Button ("Okay")) {
			Time.timeScale = 1;
			trig2 = false;
		}

	}
}