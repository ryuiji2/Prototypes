using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour{

    public static Movement instance;

    public NavMeshAgent agent;
    public enum Needs { Idle, Energy, Hunger, Hygene, Thirst }
    public Needs needs;
    public GameObject food, water, bed, shower;
    private float low = 75;

    public bool inProgress;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Needings();
        Decay();
    }

    public void Idle()
    {
        needs = Needs.Idle;
    }

    void Decay()
    {
        if (!inProgress)
        {
            needs = Needs.Idle;
            if (PlayerStats.instance.energy <= low)
            {
                needs = Needs.Energy;
            }

            if (PlayerStats.instance.hunger <= low)
            {
                needs = Needs.Hunger;
            }

            if (PlayerStats.instance.hygene <= low)
            {
                needs = Needs.Hygene;
            }

            if (PlayerStats.instance.thirst <= low)
            {
                needs = Needs.Thirst;
            }
        }
    }
    void Needings()
    {
        switch (needs)
        {
            case Needs.Idle:
                agent.SetDestination(Random.insideUnitSphere * 15 + transform.position);
                break;
            case Needs.Energy:
                agent.SetDestination(bed.transform.position);
                inProgress = true;
                break;
            case Needs.Hunger:
                agent.SetDestination(food.transform.position);
                inProgress = true;
                break;
            case Needs.Hygene:
                agent.SetDestination(shower.transform.position);
                inProgress = true;
                break;
            case Needs.Thirst:
                agent.SetDestination(water.transform.position);
                inProgress = true;
                break;
        }
    }
}
