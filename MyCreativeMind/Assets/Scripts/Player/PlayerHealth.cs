using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {


	private static PlayerHealth instance;

	public int health;
	private Player player;
	private ScreenShake shake;
	public Vector2 respawnSpot;

	public bool reset = false;
	public bool next = false;

	public bool noDam;
	private AudioSource source;

	void Awake(){

		int y = SceneManager.GetActiveScene().buildIndex;
		if( y == 11 || y == 13 || y == 15 || y == 17 || y == 0){
			Destroy(this.gameObject);
		}

		if(instance == null){
			instance = this;
			DontDestroyOnLoad(instance);
		} else {
			Destroy(gameObject);
		}
	}

	void Start(){
		source = GetComponent<AudioSource>();
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void Update(){




		int y = SceneManager.GetActiveScene().buildIndex;
		if(y == 11 || y == 13 || y == 15 || y == 17 || y == 0){
			Destroy(this.gameObject);
		}

		if(y != 11 && y != 13 && y != 15 && y != 17 && y != 0){
			if(next ==  true){
				player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
				shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
				next = false;
			}

			if(reset == true){
				shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
				player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
				player.transform.position = respawnSpot;
				health = 1;
				reset = false;
			} 

			if(y != 2){
				shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
				player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
				if(player.transform.position.y <= -50){
					
					TakeDamage(1);
				}
			} 

		}
	
			
		

		if(health <= 0){
			//Vector2 pos = new Vector2(10000, 10000);
			//player.transform.position = pos;

			Invoke("Lost", 0.5f);
			foreach(Transform child in player.GetComponent<Transform>().transform){
				player.enabled = false;
				player.GetComponent<Controller2D>().enabled = false;
				Destroy(child.gameObject);
			}
		}

		if(Input.GetKeyDown(KeyCode.M)){
			SceneManager.LoadScene("DirectiveScene");
		} 

	}

	public void TakeDamage(int damage){

		if(noDam == false){
			source.Play();
			shake.Shake(0.25f, 0.25f);
			player.Damage();
			health -= damage;
		}

	}

	void Lost(){
		reset = true;	
		CancelInvoke("Lost");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	
	}

}
