using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Camera myCamera;
    RaycastHit hit; //информация луча
    Ray ray;		//луч


    // Use this for initialization
    void Start () {
        myCamera = Camera.main;
    }
	

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) Fire();
    }


    void Fire()
    {
        Vector3 dir = myCamera.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(myCamera.transform.position, dir, out hit, Mathf.Infinity))
        {
            if (hit.transform.GetComponent<Kill>())
            {
                hit.transform.GetComponent<Kill>().Execute();
            }
        }
        GetComponent<AudioSource>().Play();
    }
}
