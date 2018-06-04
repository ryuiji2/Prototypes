using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


	public float moveSpeed;


	void Start () {
		
	}
	

	void Update () {
		Moving();
	}
	void Moving(){

		float forwardBack = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
        float leftRight = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		transform.Translate (leftRight, 0, forwardBack);
	}
}
