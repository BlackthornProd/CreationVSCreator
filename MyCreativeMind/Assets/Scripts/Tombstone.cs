using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstone : MonoBehaviour {

	private Transform player;
	public GameObject words;
	public float distance;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		words.SetActive(false);
	}

	void Update(){

		if(Vector2.Distance(transform.position, player.position) < distance){
			words.SetActive(true);
		}
	}
}
