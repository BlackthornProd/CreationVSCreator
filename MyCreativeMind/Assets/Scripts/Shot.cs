using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public float speed;
	public float lifeTime;

	public GameObject shotEffect;

	void Start(){
		Invoke("Destruction", lifeTime);
	}

	void Update(){
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

	void Destruction(){
		Instantiate(shotEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
