using UnityEngine;
using System.Collections;

public class PickUpPower : MonoBehaviour {

	public GameObject PwrPower;
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
		Debug.Log("got Power");
		PwrPower.gameObject.SetActive (false);
		particle.gameObject.SetActive (true);
		particle.GetComponent<ParticleSystem> ().enableEmission = true; 
		particle.GetComponent<ParticleSystem> ().Play ();
			Maincode.Power= Maincode.Power + 1;

	}
	IEnumerator Destroy()
	{
		yield return new WaitForSeconds (3);
		particle.GetComponent<ParticleSystem> ().enableEmission = false; 
		Destroy (gameObject);


		//audio.PlayOneShot(WalkieBeep);


	}
}