using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] objects;

	void Start(){
		for (int i = 0; i < objects.Length; i++) {
				objects[i].SetActive(false);
			}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Player")){
			for (int i = 0; i < objects.Length; i++) {
				objects[i].SetActive(true);
			}
		}
	}
}
