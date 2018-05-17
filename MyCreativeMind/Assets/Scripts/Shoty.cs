using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoty : MonoBehaviour {

	public float speed;
	public float lifeTime;
	private Spikes spikes;

	void Start(){
		spikes = GetComponent<Spikes>();
		Invoke("Death", lifeTime);
	}

	void Update(){

		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

	void Death(){
		Instantiate(spikes.effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
