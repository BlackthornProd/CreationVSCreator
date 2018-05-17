using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	[Header ("Moving and Jumping")]
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float moveSpeed = 6;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;


	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	private Controller2D controller;
	private Animator anim;

	bool facingRight = true;
	bool doubleJump = false;
	int jumpNum = 2;

	public GameObject damageEffect;
	public GameObject footEffect;
	private bool foot = false;
	public Animator hurtPanel;
	private PlayerHealth health;

	private AudioSource source;
	public AudioClip jump;
	public AudioClip jumpTwo;
	public AudioClip landing;

	void Start() {
		source = GetComponent<AudioSource>();
		health = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerHealth>();
		anim = GetComponent<Animator>();
		controller = GetComponent<Controller2D> ();
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		health.noDam = false;
	}

	void Update() {

		if(Input.GetKeyDown(KeyCode.LeftShift)){
			moveSpeed *= 2;
		} 
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			moveSpeed = moveSpeed / 2;
		}

		// detects when on the ground
		if (controller.collisions.below) {
			if(foot == true){
				source.clip = landing;
				source.Play();
				anim.SetBool("isJumping", false);
				foot = false;
				Vector2 pos = new Vector2(transform.position.x, transform.position.y - 2);
				Instantiate(footEffect, pos, Quaternion.identity);
			}
			anim.SetBool("isJumping", false);
			velocity.y = 0;
			doubleJump = false;
			jumpNum = 2;
		} else if(controller.collisions.below == false){
			anim.SetBool("isJumping", true);
			foot = true;
		}

		// detects if the player is holding the arrow keys to move
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Flip(input);



		// jump and double jump and triple jump
		if (Input.GetKeyDown(KeyCode.UpArrow) && controller.collisions.below) {
			source.clip = jump;
			source.Play();
			foot = true;
			velocity.y = jumpVelocity;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow) && doubleJump == false && !controller.collisions.below){
			source.clip = jumpTwo;
			source.Play();
			velocity.y = jumpVelocity;
			jumpNum--;
			if(jumpNum <= 0){
				doubleJump = true;
			}
		} 
	


		// handles moving and physics for jumping
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);




		if(input.x !=  0){
			anim.SetBool("isRunning", true);
		} else if(input.x == 0){
			anim.SetBool("isRunning", false);
		}


	}


	// flip the character so he is facing the direction he is moving in
	void Flip(Vector2 input){
		
		if(input.x > 0 && facingRight == false || input.x < 0 && facingRight == true){
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	public void Damage(){
		hurtPanel.SetTrigger("Hurt");
		Instantiate(damageEffect, transform.position, Quaternion.identity);
	}



}
