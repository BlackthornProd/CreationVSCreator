using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

	public Camera mainCamera;

	private float shakeAmount = 0;

	void Awake(){
		if(mainCamera == null){
			mainCamera = Camera.main;
		}
	}

	public void Shake(float amount, float length){
		shakeAmount = amount;
		InvokeRepeating("DoShake", 0f, 0.01f);
		Invoke("StopShaking", length);
	}

	void DoShake(){
		if(shakeAmount > 0){
			Vector3 camPos = mainCamera.transform.position;

			float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
			camPos.x += offsetX;
			camPos.y += offsetY;

			mainCamera.transform.position = camPos;
		}
	}

	void StopShaking(){
		CancelInvoke("DoShake");
		mainCamera.transform.localScale = Vector3.zero;
	}
}
