using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSTWO : MonoBehaviour {

	public float speed;
	private Transform target;
	private ScreenShake shake;

	private float timer;
	public float startTime;
	public Transform pos;
	public GameObject projectile;

	void Start(){

		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		timer = startTime;
	}

	void Update(){
		Vector2 pos = new Vector2(transform.position.x, target.position.y);
		transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);

		if(timer <= 0){
			Instantiate(projectile, pos, Quaternion.identity);
			timer = startTime;
		} else {
			timer -= Time.deltaTime;
		}
	}


}
