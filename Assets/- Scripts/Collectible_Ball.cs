using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible_Ball : MonoBehaviour
{
    public enum FishColor
    {
        Red,
        Green,
        Blue,
        Orange
    }

    private static int redFish = 0;
    private static int greenFish = 0;
    private static int blueFish = 0;
    private static int orangeFish = 0;

    private static Text fishScore;

    private Animator anim;
    public AudioClip saw;
    public FishColor fishColor;
    private GameObject star;
    private GameObject top_plane;
    private bool flag = true;


    void Awake()
    {
        if (star == null)
        {
            GameObject star = GameObject.Find("Star");
        }

        if (top_plane == null)
        {
            GameObject top_plane = GameObject.Find("GroundingPlane");
        }

        GameObject.Find("Star").transform.Find("Thick Corona").gameObject.SetActive(false);
        if (fishScore == null)
        {
            GameObject fishScoreGameObject = GameObject.Find("FishScore");
            fishScore = fishScoreGameObject.GetComponent<Text>();
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = saw;
    }


    void OnTriggerEnter(Collider c) {
    BallCollector bc = null;

    if (c.attachedRigidbody != null)
    {
        bc = c.attachedRigidbody.gameObject.GetComponent<BallCollector>();
    }
    if (bc != null)
    {
        switch (fishColor)
        {
            case FishColor.Red:
                redFish++;
                break;
            case FishColor.Green:
                greenFish++;
                break;
            case FishColor.Blue:
                blueFish++;
                break;
            case FishColor.Orange:
                orangeFish++;
                break;
        }

        string fishString =
        string.Format
        (
            " Red: {0}\n Green: {1}\n Blue: {2}\n Orange: {3}",
            redFish,
            greenFish,
            blueFish,
            orangeFish
        );
        fishScore.text = fishString;
        if (redFish >= 3 && greenFish >= 3 && blueFish >= 3 && orangeFish >= 3 && flag)
        {
            GameObject.Find("Star").transform.Find("Thick Corona").gameObject.SetActive(true);
            GameObject top_plane = GameObject.Find("GroundingPlane");
            fishString = " Congratulations!\n Now look to the skies\n and head towards the\n light";
            fishScore.text = fishString;
            GameObject.Find("Zelda").GetComponent<AudioSource>(). Play();
            top_plane.SetActive(false);
            flag = false;
        }

         Destroy(this.gameObject);
    }

}

}
