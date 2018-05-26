using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueManager : MonoBehaviour {

	private ContinueNumber continueNumber;
	public Animator fadePanel;
	public Animator music;

	void Start(){
		continueNumber = GameObject.FindGameObjectWithTag("Continue").GetComponent<ContinueNumber>();
	}

	public void LoadScene(){
		continueNumber.LoadNewScene();
	}

	public void NewGame(){
		continueNumber.ResetContinue();
		SceneManager.LoadScene("Level1");
	}

}
