using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : BasicItem {

	public override void GiveHygene(int value){
		base.GiveHygene(value);
	}
	public override void GiveHunger(int value){
		base.GiveHunger(value);	
	}
	public override void GiveEnergy(int value){
		base.GiveEnergy(value);
	}

}
