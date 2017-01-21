using UnityEngine;
using System.Collections;

public class Lights : MonoBehaviour {
	public GameObject light1;
	public bool onTrigger;

	// Use this for initialization
	void Start () {
		light1.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other)
	{
		onTrigger = true;
		light1.gameObject.SetActive (true);
	}
	void OnTriggerExit(Collider other)
	{
		onTrigger = false;
		light1.gameObject.SetActive (false); 


	}
}
