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
	public Enemy enemy;
	public Bullet bullet;
	public int stronger;
	public int kills;
	public float points;
	private int flashTimes = 3;

	private void Awake(){
		if(instance == null){
			instance = this;
		}
	}

	void Update () {
		UIUpdate();
		Mathf.Ceil(points);
	}

	void UIUpdate(){
		killText.text = "Kills: " + kills;
		pointText.text = "Points: " + points;
	}

	public void Stronger(){
		if(kills == stronger){
			enemy.health *= 1.1f;
			enemy.damage *= 1.05f;
			enemy.givePoints *= 1.1f;
			bullet.givePoints *= 1.1f;
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