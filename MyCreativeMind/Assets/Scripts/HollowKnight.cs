using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowKnight : MonoBehaviour {

	public float speed;

	public int health;


	private Animator anim;
	public GameObject[] spikes;
	public GameObject destroyEffect;

	void Start(){
		Physics2D.queriesStartInColliders = false;
	}

	void Update(){

		if(health <= 0){
			for (int i = 0; i < spikes.Length; i++) {
				Destroy(spikes[i].gameObject);
				Instantiate(destroyEffect, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}

		transform.Translate(Vector2.right * speed * Time.deltaTime);

		RaycastHit2D hitInfoRight = Physics2D.Raycast(transform.position, Vector2.right, 1f);
		RaycastHit2D hitInfoLeft = Physics2D.Raycast(transform.position, Vector2.left, 1f);
		if(hitInfoRight == true){
			transform.eulerAngles = new Vector3(0, 180, 0);
		}

		if(hitInfoLeft == true){
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}


	void Damage(){
		health--;
		anim.SetTrigger("Hurt");

	}
}
