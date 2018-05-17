using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {


	private Animator anim;
	public GameObject effect;
	bool destroy = false;
	public float timer = 2;

	void Start(){
		anim = GetComponent<Animator>();
	}

	void Update(){
		if(destroy == true){
			if(timer <= 0){
				Instantiate(effect, transform.position, Quaternion.identity);
				Destroy(gameObject);
			} else {
				timer -= Time.deltaTime;
			}
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player") && destroy == false){
			
			anim.SetTrigger("Squish");
			destroy = true;
		}
	
	}
}
