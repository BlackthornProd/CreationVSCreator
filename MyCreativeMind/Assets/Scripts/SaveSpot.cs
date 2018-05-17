using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSpot : MonoBehaviour {

	
	private Spots spots;
	private PlayerHealth gm;
	private Animator anim;
	public GameObject effect;
	private ScreenShake shake;
	public GameObject[] word;
	private UI ui;
	private Player player;

	public bool complete;
	public bool special;

	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerHealth>();
		anim = GetComponent<Animator>();
		spots = GameObject.FindGameObjectWithTag("Spots").GetComponent<Spots>();
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
		if(complete == true){
			ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
		}

		if(this.gameObject.tag == "Save Spot"){
			gm.respawnSpot = this.transform.position;
		}

		if(complete == false){
				for (int i = 0; i < word.Length; i++) {
					word[i].SetActive(false);
				}
			}

		
	}

	void Update(){
		if(SceneManager.GetActiveScene().name == "WinLevel"){
			special = true;
		}
		if(special == true){
			gm.noDam = true;
		}
		spots = GameObject.FindGameObjectWithTag("Spots").GetComponent<Spots>();

		if(this.gameObject.tag == "Untagged"){
			anim.SetBool("Activate", false);
		} else if(this.gameObject.tag == "Save Spot"){
			anim.SetBool("Activate", true);
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		

		if(other.CompareTag("Player") && this.gameObject.tag == "Untagged"){
			if(complete == false){
				for (int i = 0; i < word.Length; i++) {
					word[i].SetActive(true);
				}
			} else {
				player.moveSpeed = 0;
				player.jumpHeight = 0;
				gm.noDam = true;
				ui.Fade();
				Invoke("LoadNextScene", 2f);
			}
			source.volume = 0.3f;
			source.Play();
			shake.Shake(0.25f, 0.25f);
			Vector2 pos = new Vector2(transform.position.x, transform.position.y + 2);
			Instantiate(effect, pos, Quaternion.identity);
			for (int i = 0; i < spots.saveSpots.Length; i++) {
				spots.saveSpots[i].tag = "Untagged";
			}
			this.gameObject.tag = "Save Spot";
			gm.respawnSpot = this.transform.position;
			Debug.Log(gm.respawnSpot);

		}
	}

	void LoadNextScene(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerHealth>();
		gm.next = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
}
