using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour {

	public float speed;
	public GameObject[] spikyWords;
	public Transform[] pos;
	public float timeBtwShake;
	private Transform player;
	private ScreenShake shake;



	void Start(){
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}


	void Update(){

		if(player.position.x <= transform.position.x){
			transform.eulerAngles = new Vector3(0, 180, 0);
		} else {
			transform.eulerAngles = new Vector3(0, 0, 0);
		}

		transform.Translate(Vector2.right * speed * Time.deltaTime);

		if(timeBtwShake <= 0){
			shake.Shake(0.25f, 0.25f);
			timeBtwShake = .25f;
		} else {
			timeBtwShake -= Time.deltaTime;
		}
	}
}
