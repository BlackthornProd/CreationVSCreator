using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour {

	public float speed;

	void Update(){
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
}
