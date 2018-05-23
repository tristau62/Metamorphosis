using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
    public GameObject deadCopy;
    public bool dontDestroy;

	public void Execute () {
        GameObject copy = (GameObject)Instantiate(deadCopy, transform.position, transform.rotation);
        copy.transform.SetParent(transform.parent);
        
        if(!dontDestroy) Destroy(gameObject);
    }

}
