using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject shot;

	private float timeBtwShots;
	public float startTimeBtwShots;

	void Start(){
		timeBtwShots = startTimeBtwShots;
	}

	void Update(){


		if(timeBtwShots <= 0){
			if(Input.GetKey(KeyCode.Z)){
				Instantiate(shot, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
				timeBtwShots = startTimeBtwShots;
			} else if(Input.GetKey(KeyCode.D)){
				Instantiate(shot, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
				timeBtwShots = startTimeBtwShots;
			} else if(Input.GetKey(KeyCode.Q)){
				Instantiate(shot, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
				timeBtwShots = startTimeBtwShots;
			} else if(Input.GetKey(KeyCode.S)){
				Instantiate(shot, transform.position, Quaternion.Euler(new Vector3(0, 0, -180)));
				timeBtwShots = startTimeBtwShots;
			}
		} else {
			timeBtwShots -= Time.deltaTime;
		}

	}
}
