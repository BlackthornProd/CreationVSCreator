using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	public int damage;
	private PlayerHealth gm;
	private Transform player;
	private ScreenShake shake;

	public GameObject effect;

	void Start(){
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerHealth>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			shake.Shake(0.5f, 0.25f);
			gm.TakeDamage(damage);
			Instantiate(effect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	public void Death(){
		shake.Shake(0.25f, 0.25f);
		Instantiate(effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
