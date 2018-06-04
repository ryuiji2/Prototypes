using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	public GameObject player;
	public float moveSpeed;
	public float health;
	public float damage;
	public float givePoints;
	public GameObject pack;
	public int canDrop;
	public int yesDrop;
	public int dropChance;

	void Start () {
		player = Player.instance.gameObject;
		health = 100;
		damage = 10;
		givePoints = 50;

		canDrop = Random.Range(0, dropChance);
	}

	void Update () {
		transform.LookAt(player.transform.position);
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		Death();
	}
	void Death(){
		if(player.GetComponent<Player>().health <= 0){
			health = 0;
		}
		if(health <= 0){
			Manager.instance.kills++;
			Manager.instance.points += givePoints;
			Manager.instance.Stronger();
			EnemySpawn.instance.currSpawn--;

			if(canDrop == yesDrop){
				Instantiate(pack,transform.position,Quaternion.identity);
			}
			Destroy(gameObject);
		}
	}
		void OnCollisionEnter(Collision collider){
		if(player.GetComponent<Player>().invul == false){
			if(collider.transform.tag == "Player"){
				StartCoroutine(player.GetComponent<Player>().HitFlasher());
				player.GetComponent<Player>().health -= damage;

			}
		}
	}
}