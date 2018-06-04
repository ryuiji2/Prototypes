﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public Rigidbody2D rb;

    public UIManager uiManager;

	
	void Update () {
		if (Input.GetButtonDown("Start"))
		{
			rb.bodyType = RigidbodyType2D.Dynamic;
			uiManager.SpaceToPlay();
		}
	}
}
