using UnityEngine;
using System.Collections;

public class PickUpMuffle : MonoBehaviour {

	public GameObject PwrMuffle;
	public bool onTrigger;
	public GameObject particle;

	void Start () {
		particle.gameObject.SetActive (false);
		//light1.gameObject.SetActive (false);
		//particle.GetComponent<ParticleSystem> ().enableEmission = false; 
		//particle.GetComponent<ParticleSystem> ().Stop ();
	}

	void OnTriggerEnter(Collider other)
	{
		onTrigger = true;
		Debug.Log("got muffle");
		PwrMuffle.gameObject.SetActive (false);
		particle.gameObject.SetActive (true);
		particle.GetComponent<ParticleSystem> ().enableEmission = true; 
		particle.GetComponent<ParticleSystem> ().Play ();
		Maincode.Muffle = Maincode.Muffle + 1;

	}
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds (3);
		particle.GetComponent<ParticleSystem> ().enableEmission = false; 
		Destroy (gameObject);

		//audio.PlayOneShot(WalkieBeep);


	}
}