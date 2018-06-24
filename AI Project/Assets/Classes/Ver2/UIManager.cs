using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text statsText;


	void Start () {
		
	}
	
	void Update () {
		
		statsText.text = "Stats:" + "\n Energy: " + PlayerStats.instance.energy + "\n Hunger: " + PlayerStats.instance.hunger + "\n Thirst: " + PlayerStats.instance.thirst + "\n Hygene: " + PlayerStats.instance.hygene;
	}
}
