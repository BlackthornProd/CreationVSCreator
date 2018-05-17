using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTwo : MonoBehaviour {

	public float speed;
	private Transform target;
	private Spikes spike;

	private Vector2 pos;
	public float distance;
	bool setPos = false;
	public float timer;

	void Start(){
		spike = GetComponent<Spikes>();
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


	}

	void Update(){
		if(Vector2.Distance(transform.position, target.position) < distance && setPos == false){
			pos = new Vector2(target.position.x, target.position.y);
			if(timer <= 0){
				setPos = true;
			} else {
				timer -= Time.deltaTime;
			}

		}
		if(Vector2.Distance(transform.position, target.position) < distance){
			transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
		}
	

		if(Vector2.Distance(transform.position, pos) < 0.2f){
			spike.Death();
		}
	}

}
