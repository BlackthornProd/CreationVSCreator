using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationManage : MonoBehaviour {

	public Transform[] spawnPoints;

	public GameObject[] effects;

	private float time;
	public float minTime;
	public float maxTime;

	void Update(){

		if(time <= 0){
			int randPos = Random.Range(0, spawnPoints.Length);
			int randFX = Random.Range(0, effects.Length);
			Instantiate(effects[randFX], spawnPoints[randPos].position, spawnPoints[randPos].rotation);
			time = Random.Range(minTime, maxTime);
		} else {
			time -= Time.deltaTime;
		}
	}
}
