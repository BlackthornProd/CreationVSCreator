using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Out : MonoBehaviour {

	public float wait = 1.5f;

	void Update(){
		if(wait <= 0){
			gameObject.SetActive(false);
		} else {
			wait -= Time.deltaTime;
		}
	}
}
