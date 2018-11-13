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
    public float healthRegen = 2f;
    public bool inCombat = false;
    private static float levelExp;
    private float healthRegenCooldown = 1f, timer;

    void Start()
    {
        levelExp = (level + 1) * 225;
        timer = healthRegenCooldown;
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
        if (inCombat == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                RestoreHp(healthRegen);
                timer = healthRegenCooldown;
            }
        }
        else if (inCombat == true)
        {
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
    public void RestoreHp(float amount)
    {
        if (Health < 100 - amount)
        {
            Health += amount;
        }
        else if (Health >= 100 - amount) {
            Health = 100;
        }
   

    }
}
