using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public static EnemySpawn instance;

	public GameObject enemy;
	public int currSpawn;
	public int maxSpawn;
	public List <GameObject> spawnPoints;

	public float spawnTime;


	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
	void Start () {
		StartCoroutine(Spawn());
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds(spawnTime);
		if(currSpawn < maxSpawn){
			GameObject spawnLoc = spawnPoints[Random.Range(0, spawnPoints.Count)];
			Instantiate(enemy,spawnLoc.transform.position, Quaternion.identity);
			currSpawn++;
		}
		StartCoroutine(Spawn());
	}
}
