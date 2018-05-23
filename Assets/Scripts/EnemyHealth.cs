using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 100;

    public float healthBarLength;
	private float time;
    public GameObject wolf;
    Animator anim;
    AudioSource enemyAudio;
    public AudioClip deathClip;
	public Vector3 bearDir;

    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 6;
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCurrentHealth(0);
		bearDir = transform.position - GameObject.Find ("Bear").transform.position;

    }

    void OnGUI()
    {
		float dist = Vector3.Distance (transform.position, GameObject.Find ("Bear").transform.position);
		if (dist < 40) {
			Vector2 targetPos;
			targetPos = Camera.main.WorldToScreenPoint (wolf.transform.position);

			GUI.Box (new Rect (targetPos.x, Screen.height - targetPos.y, 100, 20), curHealth + "/" + maxHealth);
		}
	}

    public void AdjustCurrentHealth(int adj)
    {
        if (curHealth != 0) {
            curHealth += adj;

            if (curHealth <= 0)
            {
                curHealth = 0;
                if (anim.GetBool("isWalking"))
                {
					anim.ResetTrigger ("isWalking");
					anim.ResetTrigger ("isRunning");
                    anim.SetTrigger("isDead");
                }
                if (anim.GetBool("isRunning"))
                {
					anim.ResetTrigger ("isWalking");
					anim.ResetTrigger ("isRunning");
					anim.SetTrigger("isDead");
                }
                if (!anim.GetBool("isDead"))
                {
                    anim.SetTrigger("isDead");
                }
				enemyAudio.clip = deathClip;
                enemyAudio.Play();
            }

            if (curHealth > maxHealth)
                curHealth = maxHealth;

            if (maxHealth < 1)
                maxHealth = 1;

            healthBarLength = (Screen.width / 6) * (curHealth / (float)maxHealth);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
		gameObject.GetComponent<WolfKnock> ().BearImpact (bearDir, 50.0f);
		float timeElapsed = Time.time;
        if (collision.gameObject.tag == "Player")
        {
			if (timeElapsed - time > .75)
			{
            	AdjustCurrentHealth(-34);
				time = Time.time;
			}
        }
    }
}
