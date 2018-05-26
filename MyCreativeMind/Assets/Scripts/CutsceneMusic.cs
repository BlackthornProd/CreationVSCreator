using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneMusic : MonoBehaviour {

	public float waitStartTime;
	public float fadeOutTime;

	private Animator anim;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
		source.enabled = false;
		anim = GetComponent<Animator>();
	}

	void Update(){

		if(waitStartTime <= 0){
			source.enabled = true;
		} else {
			waitStartTime -= Time.deltaTime;
		}

		if(fadeOutTime <= 0){
			anim.SetTrigger("fadeOut");
		} else {
			fadeOutTime -= Time.deltaTime;
		}
	}
}
