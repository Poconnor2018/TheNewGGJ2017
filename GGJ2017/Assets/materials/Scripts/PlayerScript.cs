using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float maxSpeed, noiseSpeed;
    Vector3 movement;
    public AudioClip step;
    public AudioSource m_audioSource;
	public GameObject Muffle;
	public GameObject Stomp;
	public GameObject Power;
	public bool sprint;
	//public bool crouch;

	Animator anim;


	// Use this for initialization
	void Start () {
		Muffle.GetComponent<ParticleSystem>().enableEmission = false;
		Muffle.GetComponent<ParticleSystem>().Stop ();

		Stomp.GetComponent<ParticleSystem> ().enableEmission = false;
		Stomp.GetComponent<ParticleSystem> ().Stop ();

		Power.GetComponent<ParticleSystem> ().enableEmission = false;
		Power.GetComponent<ParticleSystem> ().Stop ();


		//gameObject.GetComponent<ParticleSystem> ().enableEmission = false; 
		//gameObject.GetComponent<ParticleSystem> ().Stop ();
        noiseSpeed = maxSpeed - .3f;
        m_audioSource = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		movement.x = Input.GetAxis ("Horizontal");

		movement.z = Input.GetAxis ("Vertical");

		sprint = Input.GetKey (KeyCode.LeftShift);

		if (movement.x > 0 || movement.x < 0) {
			//anim.Play ("Walk", -1, 0f);
			anim.SetBool("Walk",true);
		}
		else
			anim.SetBool("Walk",false);

		if (movement.z > 0 || movement.z < 0) {
			
			anim.SetBool("Walk",true);
		}
		else
			anim.SetBool("Walk",false);
		
		


		//crouch = Input.GetKey (KeyCode.LeftControl);

		if (movement.x == 0 && movement.z == 0) {
			
			//gameObject.GetComponent<ParticleSystem> ().Stop ();
			//gameObject.GetComponent<ParticleSystem> ().enableEmission = false; 


		} else {
		}
		//gameObject.GetComponent<ParticleSystem> ().Play ();
		//gameObject.GetComponent<ParticleSystem> ().enableEmission = true; 
		//gameObject.GetComponent<ParticleSystem> ().startSize = 2.92f;

		if (Maincode.Muffle >= 1) {
			if (Input.GetKeyDown ("e")) {
				Muffle.GetComponent<ParticleSystem> ().Play ();
				Maincode.Muffle = Maincode.Muffle - 1;
				if (Input.GetKeyDown ("e")) 
				{
					anim.Play ("Muffle", -1, 0f);

				}

			}
		}
		if (Maincode.Stomp >= 1) {
			if (Input.GetKeyDown ("r")) {
				Stomp.GetComponent<ParticleSystem> ().Play ();
				Maincode.Stomp = Maincode.Stomp - 1;
				if (Input.GetKeyDown ("r")) 
				{
					anim.Play ("Stomp", -1, 0f);

				}
			}
		}
		if (Maincode.Power >= 1) {
			if (Input.GetKeyDown ("t")) {
				Power.GetComponent<ParticleSystem> ().Play ();
				Maincode.Power = Maincode.Power - 1;
			}
		}

	}


	void FixedUpdate () {
		/*if (crouch) {
			Debug.Log("Crouch down");
			Vector3 crouchSpeed = movement * maxSpeed / 2;
			if (crouchSpeed.magnitude > noiseSpeed)
				m_audioSource.PlayOneShot(step);
			transform.position += crouchSpeed;
			gameObject.GetComponent<ParticleSystem> ().startSize = 0;
			
		}*/






		if (sprint)
		{
			Debug.Log("Shift down");
			Vector3 sprintSpeed = movement * maxSpeed * 2;

			if (sprintSpeed.magnitude > noiseSpeed)
				m_audioSource.PlayOneShot(step);
			transform.position += sprintSpeed;
			anim.SetBool("Run",true);

			//gameObject.GetComponent<ParticleSystem> ().startSize = 5;
		}
		if (!sprint)
		{
			Debug.Log("Shift up");
			Vector3 walkSpeed = movement * maxSpeed;
			if (walkSpeed.magnitude > noiseSpeed)
				m_audioSource.PlayOneShot(step);
			transform.position += walkSpeed;
			anim.SetBool("Run",false);
			//gameObject.GetComponent<ParticleSystem>().Play();
			//gameObject.GetComponent<ParticleSystem> ().startSize = 2.92f;
		}

	
	}
}
