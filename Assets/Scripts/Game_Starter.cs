using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Starter : MonoBehaviour {

    public enum Door
    {
        Bird, 
        Shark, 
        Bear,
        Home
    }

    public Door door;

  
    void OnTriggerEnter(Collider c)
    {
        
        switch (door)
        {
            case Door.Bird:
                if (GameManager.bird < 1)
                {
                    SceneManager.LoadScene(3);
                    GameManager.bird += 1;
                }
                break;
            case Door.Shark:
                if (GameManager.shark < 1)
                {
                    SceneManager.LoadScene(2);
                    GameManager.shark += 1;
                }
                break;
            case Door.Bear:
                if (GameManager.bear < 1)
                {
                    SceneManager.LoadScene(1);
                    GameManager.bear += 1;
                }
                break;
            case Door.Home:
                SceneManager.LoadScene(0);
                GameManager.score += 1;
                break;
        }


    }
}