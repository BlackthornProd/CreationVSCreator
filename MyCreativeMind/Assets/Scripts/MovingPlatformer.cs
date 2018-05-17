using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformer : MonoBehaviour {


	public float speed;

	public Transform pointA;

	public COG cog;
	private bool next = false;


	void Update(){

		if(cog.call == true){

				transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
				if(transform.position == pointA.position){
					next = true;
				}
			} 
		}
	}

