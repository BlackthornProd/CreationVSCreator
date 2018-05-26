using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicTitle : MonoBehaviour {

	private static MusicTitle instance;
	private Animator anim;
	public int maxLevels;
	public int[] levels;
	bool stay;

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(instance);
		} else if(instance != null && instance.tag == this.tag){
			Destroy(gameObject);
		}

		anim = GetComponent<Animator>();
	}


	void Update(){

		if(maxLevels == 3){
			if(SceneManager.GetActiveScene().buildIndex != levels[0] && SceneManager.GetActiveScene().buildIndex != levels[1] && SceneManager.GetActiveScene().buildIndex != levels[2]){
				StartCoroutine(FadeOut());
			}
		} else if(maxLevels == 4){
			if(SceneManager.GetActiveScene().buildIndex != levels[0] && SceneManager.GetActiveScene().buildIndex != levels[1] && SceneManager.GetActiveScene().buildIndex != levels[2]&& SceneManager.GetActiveScene().buildIndex != levels[3]){
				StartCoroutine(FadeOut());
			}
		} else if(maxLevels == 1){
			if(SceneManager.GetActiveScene().buildIndex != levels[0]){
				StartCoroutine(FadeOut());
			}
		} else if(maxLevels == 2){
			if(SceneManager.GetActiveScene().buildIndex != levels[0] && SceneManager.GetActiveScene().buildIndex != levels[1]){
				StartCoroutine(FadeOut());
			}
		}

	}

	IEnumerator FadeOut(){
		anim.SetTrigger("fadeOut");
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
