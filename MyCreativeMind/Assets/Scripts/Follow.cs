using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	public float speed;

	private Transform player;

	public float distance;

	void Start(){

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update(){
		if(Vector2.Distance(transform.position, player.position) < distance){
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
		}
	
	}
}
