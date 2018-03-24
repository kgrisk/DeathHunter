using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public static PlayerController Instance;
	private CharacterController characterController;
	private Vector3 playerMovement;
	private float playerDirection;
	private float verticalMovement;
	private float horizontalMovement;


	private bool secondJump;
	private bool wallJump;

	public float jumpForce;
	public float playerSpeed;
	public float gravity;

	public AudioSource audioWalking;
	public Animator anim;
	// Use this for initialization
	public bool jump;
	void Start () {
		
		//anim = GetComponentInChildren<Animator> ();
		characterController = GetComponentInChildren<CharacterController> ();
		secondJump = true;
		wallJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerInput ();
		playerDirection = Input.GetAxis ("Horizontal");
		anim.SetFloat("speed", Mathf.Abs(playerDirection));
		transform.localScale =new Vector3( Mathf.Sign (playerDirection),transform.localScale.y,transform.localScale.z);
		horizontalMovement = playerDirection * playerSpeed;

		if (characterController.isGrounded) {
//			anim.Play ("Run");
			verticalMovement = -characterController.stepOffset * Time.deltaTime;
			anim.SetLayerWeight (0, 1);
			anim.SetLayerWeight (1, 0);
			wallJump = false;

			if (jump) {
				anim.SetLayerWeight (0, 0);
				anim.SetLayerWeight (1, 1);
			//	anim.Play ("Jump");
				verticalMovement = jumpForce;
				secondJump = true;
			}

		} else {
			
			verticalMovement -= gravity * Time.deltaTime;


			if (jump && secondJump) {
				verticalMovement = jumpForce;
				secondJump = false;
			}

		}
		if (!wallJump) {
			playerMovement.x = horizontalMovement;

		}
		playerMovement.y = verticalMovement;
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		playerMovement.z = 0;

		characterController.Move (playerMovement * Time.deltaTime);

		if(Mathf.Approximately(characterController.velocity.x,0.0f)){
			audioWalking.Stop();
			Debug.Log(audioWalking.isPlaying);
		}
		else if(!audioWalking.isPlaying){
			audioWalking.Play();
			Debug.Log (audioWalking.isPlaying);
		}
		jump = false;
	}
	public void PlayerInput(){
		if (Input.GetKeyDown (KeyCode.E)) {
			anim.SetTrigger ("attack");
		}
		if (Input.GetKeyDown (KeyCode.Space)){
			jump = true;
		}
	}


	private void OnControllerColliderHit(ControllerColliderHit hit){
		if (characterController.collisionFlags == CollisionFlags.Sides) {
			if (jump) {
				Debug.DrawRay (hit.point, hit.normal, Color.red, 5f);
				playerMovement = hit.normal * playerSpeed;
				verticalMovement = jumpForce;
				wallJump = true;
			}
		
		}
	}
}
