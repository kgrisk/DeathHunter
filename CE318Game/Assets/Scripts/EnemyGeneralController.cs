using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyGeneralController : MonoBehaviour {
	//public float lookRadius = 10f;	// Detection range for player
	public Transform target;	// Reference to the player
	public NavMeshAgent agent; // Reference to the NavMeshAgent
	// Use this for initialization
	public bool dead = false;
	Animator anim;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").gameObject.transform;
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator> ();
		agent.speed = GameMode.instance.gameMode * agent.speed;


	}

	// Update is called once per frame
	void Update () {
		// Distance to the target

		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Awake")) {
			
			if (target.gameObject.activeSelf && !GetComponent<HealthManager>().dead) {
				GetComponent<CapsuleCollider> ().enabled = true;
				float distance = Vector3.Distance (target.position, transform.position);

					agent.SetDestination (target.position);

				// If inside the lookRadius
				//if (distance <= lookRadius) {
				// Move towards the target

				FaceTarget ();

				//}
				anim.SetFloat ("speed", agent.velocity.magnitude);
			} else {
				agent.velocity = Vector3.zero;
				GetComponent<CapsuleCollider> ().enabled = false;
			}
		}
	}
	// Rotate to face the target
	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	// Show the lookRadius in editor
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
//		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
