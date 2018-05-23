using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
    public GameObject[] objects;


	// Use this for initialization
	void Start () 
    {
        int n = Random.Range(2, 4);
        for (int i = 0; i < n; i++)
        {
            GameObject obj = Instantiate(objects[Random.Range(0, objects.Length)]);
            obj.transform.SetParent(transform.parent);
            obj.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 1);
            obj.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360));
            obj.transform.localScale += Vector3.one * Random.Range(-1f,1f);
        }
        Destroy(gameObject);
	}
}
