using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : BasicItem {

	public override void GiveEnergy(int value){
		base.GiveEnergy(value);
	}

	public override void GiveHunger(int value){
		base.GiveHunger(value);
	}
	public override void GiveThirst(int value){
		base.GiveThirst(value);
	}
}
