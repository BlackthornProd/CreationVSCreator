using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScene : MonoBehaviour {

	private ContinueNumber continueNumber;
	public int index;

	void Start(){
		continueNumber = GameObject.FindGameObjectWithTag("Continue").GetComponent<ContinueNumber>();
		continueNumber.levelNumber = index;
		continueNumber.New();
	}
}
