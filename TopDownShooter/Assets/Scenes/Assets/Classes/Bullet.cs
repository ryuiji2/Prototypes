using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	int damage;
	public float givePoints;
	public GameObject particle;

void Start(){
	damage = 8;
}
	public void OnCollisionEnter(Collision collider){
		if(collider.transform.tag == "Enemy"){
			Instantiate(particle,transform.position, Quaternion.identity);
			collider.transform.GetComponent<Enemy>().health -= damage;
			Manager.instance.points += givePoints;
			Destroy(gameObject);
		}
	}
}
