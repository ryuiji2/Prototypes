﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		Destroy(gameObject, 1.0f);
	}
}
