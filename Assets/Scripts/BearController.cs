using UnityEngine;



public class BearController : MonoBehaviour
{
	float Blend = 0f;
	private Animator anim;
	private Rigidbody rbody;
    private BearHealth health;
	float stored;
	float savedTime;
	float inputForward;
    void Update()
	{
        
		if (anim == null)
			anim = GetComponent<Animator> ();
		if (rbody == null)
			rbody = GetComponent<Rigidbody> ();
        if (health == null)
            health = GetComponent<BearHealth>();
		rbody.AddForce(Vector3.down * 1000);
        if (health.currentHealth > 0)
        {
			
			if (Input.GetKey(KeyCode.W))
            {
				anim.SetTrigger ("isRunning");
				anim.ResetTrigger ("isAttacking");
                Blend += Time.deltaTime;

            }
            else if (Input.GetKey(KeyCode.C))
            {
                stored = .4f;
            }
            else
            {
                Blend -= Time.deltaTime;
            }

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 25.0f;



            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);


            //anim.SetFloat ("Blend", stored);
            Blend = Mathf.Clamp(Blend, 0f, .5f);
            anim.SetFloat("Blend", stored);
            stored = Blend;
        }
	}
}