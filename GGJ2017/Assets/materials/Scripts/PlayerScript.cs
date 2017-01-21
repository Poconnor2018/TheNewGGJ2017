using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float maxSpeed, noiseSpeed;
    Vector3 movement;
    public AudioClip step;
    public AudioSource m_audioSource;
	public bool sprint;
	public bool crouch;


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<ParticleSystem> ().enableEmission = false; 
		gameObject.GetComponent<ParticleSystem> ().Stop ();
        noiseSpeed = maxSpeed - .3f;
        m_audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        
        movement.x = Input.GetAxis ( "Horizontal" );

        movement.z = Input.GetAxis ( "Vertical" );
		sprint = Input.GetKey (KeyCode.LeftShift);
		crouch = Input.GetKey (KeyCode.LeftControl);

		if (movement.x == 0 && movement.z == 0) {
			gameObject.GetComponent<ParticleSystem> ().Stop ();
			gameObject.GetComponent<ParticleSystem> ().enableEmission = false; 
		} else {
		}gameObject.GetComponent<ParticleSystem> ().Play ();
		gameObject.GetComponent<ParticleSystem> ().enableEmission = true; 
		//gameObject.GetComponent<ParticleSystem> ().startSize = 2.92f;
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
			gameObject.GetComponent<ParticleSystem> ().startSize = 5;
		}
		if (!sprint)
		{
			Debug.Log("Shift up");
			Vector3 walkSpeed = movement * maxSpeed;
			if (walkSpeed.magnitude > noiseSpeed)
				m_audioSource.PlayOneShot(step);
			transform.position += walkSpeed;
			gameObject.GetComponent<ParticleSystem>().Play();
			gameObject.GetComponent<ParticleSystem> ().startSize = 2.92f;
		}

	
	}
}
