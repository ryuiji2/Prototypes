using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : BasicItem {

    bool canPlay;

    public override void GiveEnergy(int value){
        if (canPlay)
        {
            StartCoroutine(OverTime(value));
        }
    }

    IEnumerator OverTime(int overTimeValue)
    {
		canPlay = false;
        while(PlayerStats.instance.energy < 100)
		{
            PlayerStats.instance.energy += overTimeValue;
            yield return new WaitForSeconds(1);
		}
        canPlay = true;
    }
}
