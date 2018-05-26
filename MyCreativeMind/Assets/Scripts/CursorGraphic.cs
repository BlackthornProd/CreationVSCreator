using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorGraphic : MonoBehaviour {



	void Start(){
		Cursor.visible = false;
	}

	void Update(){
		transform.position = Input.mousePosition;

	}
}
