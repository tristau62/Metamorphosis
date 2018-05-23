using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RingManager : MonoBehaviour
{
    private int maxRings;

    public static int score;
    public GameObject ringList;
    public GameObject goal;

    Text text;

    void Awake () {
    	maxRings = ringList.transform.childCount;
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update () {
        text.text = "Rings: " + score + " / " + maxRings;

        if (score >= maxRings && !goal.active) {
        	goal.SetActive(true);
        }
    }
}