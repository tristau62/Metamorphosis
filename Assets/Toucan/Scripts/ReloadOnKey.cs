using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadOnKey : MonoBehaviour {
    public KeyCode key = KeyCode.R;

    void Update()
    {
        if (Input.GetKey(key))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
