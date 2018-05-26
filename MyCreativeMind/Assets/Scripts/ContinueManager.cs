using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueManager : MonoBehaviour {

	private ContinueNumber continueNumber;
	public GameObject fadePanel;


	void Start(){
		continueNumber = GameObject.FindGameObjectWithTag("Continue").GetComponent<ContinueNumber>();
	}

	public void LoadScene(){
		StartCoroutine(FadeLoadScene());
	}

	public void NewGame(){
		StartCoroutine(FadeNewGame());
	}

	IEnumerator FadeLoadScene(){
		fadePanel.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		continueNumber.LoadNewScene();
	}

	IEnumerator FadeNewGame(){
		fadePanel.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		continueNumber.ResetContinue();
		SceneManager.LoadScene("Level1");
	}

}
