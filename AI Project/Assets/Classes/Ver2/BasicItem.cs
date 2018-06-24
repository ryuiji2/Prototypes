using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour{


    public int energyVal;
    public int foodVal;
    public int hygeneVal;
    public int waterVal;


    public virtual void OnCollisionEnter(Collision player)
    {
        if(player.transform.tag == "Player"){
            Movement.instance.Idle();
            Movement.instance.inProgress = false;
            GiveEnergy(energyVal);
            GiveHunger(foodVal);
            GiveHygene(hygeneVal);
            GiveThirst(waterVal);
		}
    }
    public virtual void GiveEnergy(int value)
    {
        PlayerStats.instance.energy += value;
    }
    public virtual void GiveHunger(int value)
    {
        PlayerStats.instance.hunger += value;
    }
    public virtual void GiveHygene(int value)
    {
        PlayerStats.instance.hygene += value;
    }
    public virtual void GiveThirst(int value)
    {
        PlayerStats.instance.thirst += value;
    }
}

