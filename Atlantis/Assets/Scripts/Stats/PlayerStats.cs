using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float Health = 100f;
    public float damage = 20f;
    public float cooldown = 1f;
    public float level = 1f;
    public float experience = 0f;
    public int storageCapacity = 20;

    private static float levelExp;

    void Start()
    {
        levelExp = (level + 1) * 225;
    }

    void Update () {
        if (Health <= 0) {
            Health = 0;
        }
        if (experience >= levelExp) {
            level++;
            experience = 0;
            levelExp = (level + 1) * 225;
        }
	}

    public void DealDamage(float damageAmount) {
        if (Health > 0)
        {
            Health = Health - damageAmount;
        }
    }
    public void AddExperiance(float exp) {
        if (experience < levelExp) {
            experience += exp;
        }
    }
}
