using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {


	public AudioClip animalSound;
	public AudioSource animalSoundS;
	public AudioClip walking;
	public AudioSource walkingS;
	public AudioClip eating;
	public AudioSource eatingS;
	public AudioClip running;
	public AudioSource runningS;
	public AudioClip attacking;
	public AudioSource attackingS;
	public AudioClip death;
	public AudioSource deathS;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AnimalSound()
	{
		animalSoundS.PlayOneShot (animalSound);
	}

	void Walking()
	{
		walkingS.PlayOneShot (walking);
	}

	void Eating()
	{
		eatingS.PlayOneShot (eating);
	}

	void Running()
	{
		runningS.PlayOneShot (running);
	}

	void Attacking()
	{
		attackingS.PlayOneShot (attacking);
	}

	void Death()
	{
		deathS.PlayOneShot (death);
	}
}
