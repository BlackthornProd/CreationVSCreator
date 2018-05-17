using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

	public GameObject fadePanel;

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			StartCoroutine(FadeOut());
		}
	}

	IEnumerator FadeOut(){
		fadePanel.SetActive(true);
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Title");
	}
}
