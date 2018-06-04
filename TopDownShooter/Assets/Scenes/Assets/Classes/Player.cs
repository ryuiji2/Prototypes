using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Player instance;
	private Vector3 startLoc;
	public float health;
	public bool invul = false;
	public Material myMaterial;
	public Color collideColor;
	public Color normalColor;
	public GameObject bullet;
	public GameObject shootLoc;
	int flashTimes = 5;
	bool allowFire = true;
	int currAmmo;
	int maxAmmo = 250;
	bool isReloading;
	public GameObject deathText;
	
	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
	void Start () {
		currAmmo = maxAmmo;
		myMaterial = GetComponent<Renderer>().material;
		startLoc = transform.position;
	}
	

	void Update () {
		Manager.instance.healthText.text = "Health: " + health;
		Manager.instance.ammoText.text = "Ammo: " + currAmmo + "/" + maxAmmo;

		if(health >= 100){
			health = 100;
		}
		if(health <= 0){
			Death();
		}
		Shoot();
		Reload();
	}

	void Shoot(){
		if(Input.GetMouseButton(0) && allowFire && currAmmo > 0){
			currAmmo--;
			GameObject spawnedBullet = Instantiate(bullet, shootLoc.transform.position, Quaternion.Euler(new Vector3(0,0,90)));
			spawnedBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
			Destroy (spawnedBullet, 2.0f);
			StartCoroutine(FireRate());
		}
	}
	IEnumerator FireRate(){
		allowFire = false;
		yield return new WaitForSeconds(0.05f);
		allowFire = true;
	}

	void Reload(){
		if(currAmmo <= 0){
			StartCoroutine(ReloadTime());
			if(isReloading == false){
				StartCoroutine(ReloadFlash());
			}
		}
	}
	IEnumerator ReloadTime(){

		yield return new WaitForSeconds(2.5f);
		currAmmo = maxAmmo;

	}
	IEnumerator ReloadFlash(){
		isReloading = true;
		for(int i = 0; i < flashTimes; i++)
		{
			Manager.instance.reloadingText.SetActive(true);
			yield return new WaitForSeconds(0.25f);
			Manager.instance.reloadingText.SetActive(false);
			yield return new WaitForSeconds(0.25f);
		}
		isReloading = false;
	}
	public IEnumerator HitFlasher(){
		invul = true;

		for(int i = 0; i < flashTimes; i++)
		{
			myMaterial.color = collideColor;
			yield return new WaitForSeconds(0.2f);
			myMaterial.color = normalColor;
			yield return new WaitForSeconds(0.2f);
		}
		invul = false;
	}

	void OnCollisionEnter(Collision collider){
		if(collider.transform.tag == "HealthPack"){
			health += collider.transform.GetComponent<Healthpack>().giveHealth;
			Destroy(collider.gameObject);
		}
	}

	void Death(){
		Manager.instance.enemy.health = 0;
		Manager.instance.points = 0;
		Manager.instance.kills = 0;
		Manager.instance.enemy.health = 100;
		Manager.instance.enemy.damage = 10;
		Manager.instance.bullet.givePoints = 10;
		Manager.instance.enemy.givePoints = 50;
		currAmmo = maxAmmo;
		invul = false;
		myMaterial.color = normalColor;
		transform.position = startLoc;
		StartCoroutine(DeathFlash());

	}

	IEnumerator DeathFlash(){
		deathText.SetActive(true);
		yield return new WaitForSeconds(0.01f);
		health = 100;
		yield return new WaitForSeconds(1);
		deathText.SetActive(false);
	}
}
