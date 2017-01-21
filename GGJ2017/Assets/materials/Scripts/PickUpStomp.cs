using UnityEngine;
using System.Collections;

public class PickUpStomp : MonoBehaviour {

	public GameObject PwrStomp;
	public GameObject particle;
	public bool onTrigger;

	// Use this for initialization
	void Start () {
		particle.gameObject.SetActive (false);
		//light1.gameObject.SetActive (false);
		//particle.GetComponent<ParticleSystem> ().enableEmission = false; 
		//particle.GetComponent<ParticleSystem> ().Stop ();
	}

	void OnTriggerEnter(Collider other)
	{
		onTrigger = true;
		Debug.Log("got stomp");
		PwrStomp.gameObject.SetActive (false);
		particle.gameObject.SetActive (true);
		particle.GetComponent<ParticleSystem> ().enableEmission = true; 
		particle.GetComponent<ParticleSystem> ().Play ();
		Maincode.Stomp = Maincode.Stomp + 1;

	}
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
		particle.GetComponent<ParticleSystem> ().enableEmission = false; 

		//audio.PlayOneShot(WalkieBeep);


	}

	}
