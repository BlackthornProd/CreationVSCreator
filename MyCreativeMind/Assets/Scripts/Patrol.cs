using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	private float speed;
	public float startSpeed;
	public Transform checkPoint;


	private bool movingRight = false;


	void Start(){

		Physics2D.queriesStartInColliders = false;
		speed = startSpeed;

	}

	void Update(){

		transform.Translate(Vector2.right * speed * Time.deltaTime);


		RaycastHit2D hitInfo = Physics2D.Raycast(checkPoint.position, Vector2.down, 10f);
		if(hitInfo.collider == false){
			if(movingRight == false){
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;

			} else {
				transform.eulerAngles = new Vector3(0, 180, 0);
				movingRight = false;
			}

		}
	
	}
}
