using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniSceneManager : MonoBehaviour {

	public float waitTime;

	public GameObject fade;

	void Update(){

		waitTime -= Time.deltaTime;
		

		if(waitTime < 0){
			StartCoroutine(LoadScene());
		}
	}

	IEnumerator LoadScene(){
		fade.SetActive(true);
		yield return new WaitForSeconds(4f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
