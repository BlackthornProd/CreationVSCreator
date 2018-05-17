using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueNumber : MonoBehaviour {

	private static ContinueNumber instance;

	public int levelNumber;

	void Awake(){
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(instance);
		} else {
			Destroy(gameObject);
		}
	}

	public void New(){
		if(levelNumber > PlayerPrefs.GetInt("Number", 0)){
			PlayerPrefs.SetInt("Number", levelNumber);
		}
	}

	public void ResetContinue(){
		PlayerPrefs.SetInt("Number", 3);
	}

	public void LoadNewScene(){
		SceneManager.LoadScene(PlayerPrefs.GetInt("Number", 0));
	}
}
