using UnityEngine;
using System.Collections;

public class RespawnArround : MonoBehaviour
{
    public GameObject enemy;
    public float radius;
    public float timeRate = 5;
    float time;


    void Update()
    {
        if (Time.time > time)
        {
            GameObject clone = Instantiate(enemy);
            clone.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            clone.transform.Translate(transform.forward * radius);

            time = Time.time + timeRate;
        }
    }
}
