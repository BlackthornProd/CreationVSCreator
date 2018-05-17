using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour {

	public float waitTime;
	public bool goStart;
	public string sceneName;

	void Update(){

		if(waitTime <= 0){
			if(goStart == true){
				SceneManager.LoadScene(sceneName);
			} else {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
	
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
