using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COG : MonoBehaviour {

	public bool call = false;


	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			call = true;
		}
	}
}
