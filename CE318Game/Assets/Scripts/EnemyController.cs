using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;	// Detection range for player
	public Transform target;	// Reference to the player
	public NavMeshAgent agent; // Reference to the NavMeshAgent
	// Use this for initialization
	public bool dead = false;
	Animator anim;
	bool dontPlay;
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator> ();
		agent.speed = GameMode.instance.gameMode * agent.speed;
	}

	// Update is called once per frame
	void Update () {
		// Distance to the target
		if (target.gameObject.activeSelf && !GetComponent<HealthManager> ().dead) {
			GetComponent<CapsuleCollider> ().enabled = true;
			float distance = Vector3.Distance (target.position, transform.position);

			// If inside the lookRadius
			if (distance <= lookRadius) {
				// Move towards the target
				agent.SetDestination (target.position);


			}
			anim.SetFloat ("speed", agent.velocity.magnitude);
		} else {
			agent.velocity = Vector3.zero;
			GetComponent<CapsuleCollider> ().enabled = false;
			if(!dontPlay){
				GetComponent<AudioSource> ().Play();
				dontPlay = true;
			}
		}
	}


	// Show the lookRadius in editor
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
