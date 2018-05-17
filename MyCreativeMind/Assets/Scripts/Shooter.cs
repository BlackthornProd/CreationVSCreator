using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	private float timeBtwShots;
	public float startTimeBtwShots;
	public float life;

	public Shoty shot;
	public Transform shotPoint;

	void Start(){

		timeBtwShots = startTimeBtwShots;
	}

	void Update(){

		if(timeBtwShots <= 0){
			Shoty instance = (Shoty)Instantiate(shot, shotPoint.position, shotPoint.rotation);
			instance.lifeTime = life;
			timeBtwShots = startTimeBtwShots;
		} else {
			timeBtwShots -= Time.deltaTime;
		}
	}
}
