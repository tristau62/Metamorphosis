using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LowPolyAnimalPack.DemoScene
{
    public class EnemyAI : MonoBehaviour
    {
        private EnemyHealth enemyHealth;
        private DEMO_Animal wander;
        private Animator anim;
        
        private float maxDist, maxDistSquared, dotProd;
        private Vector3 ray, enemyDir;
        public GameObject player;
        public AudioClip wolfAggro;
        AudioSource enemyAudio;
        private bool inFront, closeTo;

        private Transform target, enemy;
        int movementSpd = 6;
        int rotSpeed = 4;

        // Use this for initialization
        void Start()
        {
            enemyHealth = GetComponent<EnemyHealth>();
            wander = GetComponent<DEMO_Animal>();
            anim = GetComponent<Animator>();
            enemyAudio = GetComponent<AudioSource>();

            maxDist = 150f;
            maxDistSquared = maxDist * maxDist;

            target = player.transform;
            enemy = transform;

		

        }

        // Update is called once per frame
        void Update()
        {
            if (enemyHealth.curHealth == 0)
            {
                wander.enabled = false;
                wander.StopAllCoroutines();
                movementSpd = 0;
                rotSpeed = 0;
			} else if (enemyHealth.curHealth > 0)
            {
                ray = player.transform.localPosition - transform.localPosition;
                enemyDir = transform.TransformDirection(Vector3.forward);
                dotProd = Vector3.Dot(ray, enemyDir);
                inFront = dotProd > 0.0;
                closeTo = ray.sqrMagnitude < maxDistSquared;

                RaycastHit raycastHit;
				if (Physics.Raycast (transform.position, ray, out raycastHit, maxDist) && raycastHit.collider.gameObject == player) {
					wander.enabled = false;
					wander.StopAllCoroutines ();
					if (!anim.GetBool ("isRunning")) {	
						anim.ResetTrigger ("isWalking");
						anim.SetTrigger ("isRunning");
						if (anim.GetBool ("isWalking")) {
							anim.SetTrigger ("isWalking");
						}
						enemyAudio.clip = wolfAggro;
						enemyAudio.Play ();
					} else if (anim.GetBool ("isWalking")) {
						anim.SetTrigger ("isWalking");
					}
					enemy.rotation = Quaternion.Slerp (enemy.rotation, Quaternion.LookRotation (target.position - enemy.position), rotSpeed * Time.deltaTime);
					enemy.position += enemy.forward * movementSpd * Time.deltaTime;
				} else if (player.transform.position.y - transform.position.y > 2) {
					anim.ResetTrigger ("isWalking");
					anim.ResetTrigger ("isRunning");
				}
            }
        }
    }
}
