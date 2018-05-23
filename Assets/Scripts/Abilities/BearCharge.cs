using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCharge : MonoBehaviour {
    public GameObject bear;
    public bool charge;
    float savedTime;
    Animator anim;

	// Use this for initialization
	void Start () {
        charge = false;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.C))
        {
            charge = true;
            savedTime = Time.time;
            anim.SetFloat("Blend", 0.4f);
        }
        if (Time.time - savedTime <= 2.6f && charge == true)
        {
            bear.transform.position += Vector3.right * Time.deltaTime * 5.0f;
        }
        else if (Time.time - savedTime > 2.6f)
        {
            savedTime = Time.time;
            charge = false;
            anim.SetFloat("Blend", 0.0f);
        }
    }
}
