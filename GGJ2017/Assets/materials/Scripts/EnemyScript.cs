using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float MaxSpeed;

    UnityEngine.AI.NavMeshAgent agent;
    Transform player;
	// Use this for initialization
	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        agent.speed = MaxSpeed;
        player = GameObject.Find ( "Player" ).transform;
        agent.updateRotation = false;

	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = player.position;
		
	}
}
