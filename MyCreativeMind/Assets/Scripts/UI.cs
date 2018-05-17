using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	private PlayerHealth gm;
	public Image[] hearts;

	public Color normal;
	public Color faded;

	public GameObject fadePanel;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerHealth>();
	}

	void Update(){


		for (int i = 0; i < hearts.Length; i++) {
			if(i < gm.health){
				hearts[i].color = normal;
			} else {
				hearts[i].color = faded;
			}
		}

	}

	public void Fade(){
		fadePanel.SetActive(true);
	}
}
