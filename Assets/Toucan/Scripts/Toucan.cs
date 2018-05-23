using UnityEngine;
using System.Collections;

public class Toucan : MonoBehaviour {
    public GameObject missile;    

    Transform player_target;
    bool attack;


	// Use this for initialization
	void Start () {
        //transform.position += new Vector3(0, 50, 0);
        player_target = GameObject.Find("Player").transform;
	}
	

	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, player_target.position);
        transform.localPosition += transform.forward * 0.2f;

        if(attack)
        {
            transform.LookAt(player_target);
            if (distance < 35f)
            {
                Attack();
                attack = false;
            }
        }
        else
        {
            if (distance > 100f) attack = true;
        }
    }

    void Attack()
    {
        transform.localEulerAngles += new Vector3(-20, 0, 0);
        GameObject m = (GameObject)Instantiate(missile, transform.position, Quaternion.identity);
        m.transform.LookAt(player_target);
    }
}
