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

	void Awake () {
		player = Player.instance.gameObject;

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
				Vector3 dropLoc = new Vector3(transform.position.x, -0.4f, transform.position.z);
				Instantiate(pack,dropLoc,Quaternion.identity);
			}
			Destroy(gameObject);
		}
	}
		void OnCollisionEnter(Collision collider){
		if(player.GetComponent<Player>().invul == false){
			if(collider.transform.tag == "Player"){
				player.GetComponent<Player>().StartFlasher();
				player.GetComponent<Player>().health = Mathf.Ceil(player.GetComponent<Player>().health -= damage);

			}
		}
	}
}