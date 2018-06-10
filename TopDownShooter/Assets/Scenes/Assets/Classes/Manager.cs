using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour {


	public static Manager instance;
	public Text killText;
	public Text pointText;
	public Text healthText;
	public Text ammoText;
	public GameObject reloadingText;
	public GameObject strongerText;
	public GameObject pauseText;
	public Enemy enemy;
	public Bullet bullet;
	public int stronger;
	public int kills;
	public float points;
	private int flashTimes = 3;

	bool paused;



	private void Awake(){
		if(instance == null){
			instance = this;
		}
	}

	void Start(){
		enemy.health = 100;
		enemy.damage = 10;
		enemy.moveSpeed = 5;
		enemy.givePoints = 50;
		bullet.givePoints = 10;
	}

	void Update () {
		UIUpdate();
		Pause();
	}

	void Pause()
	{
		if(Input.GetButtonDown("Esc"))
		{
			paused = !paused;
		}

		if(paused){
			pauseText.SetActive(true);
			Time.timeScale = 0;
		} else{
			Time.timeScale = 1;
			pauseText.SetActive(false);
		}
	}
	void UIUpdate(){
		killText.text = "Kills: " + kills;
		pointText.text = "Points: " + "\n" + points;
	}

	public void Stronger(){
		if(kills == stronger){
			enemy.health *= 1.1f;
			enemy.damage *= 1.05f;
			enemy.moveSpeed *= 1.15f;
			enemy.givePoints = Mathf.Ceil(enemy.givePoints *= 1.1f);
			bullet.givePoints = Mathf.Ceil(bullet.givePoints *= 1.1f);
			stronger *= 2;
			StartCoroutine(StrongerFlash());
		}
}

	public IEnumerator StrongerFlash(){

		for(int i = 0; i < flashTimes; i++)
		{
			strongerText.SetActive(true);
			yield return new WaitForSeconds(0.2f);
			strongerText.SetActive(false);
			yield return new WaitForSeconds(0.2f);
		}
	}
}