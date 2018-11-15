using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

    public float health = 100f;
    public float damage = 5f;
    public float lookRadius = 10f;
    public float cooldown = 2f;
    public float giveExp = 50f;

    void Update()
    {
        if (health <= 0) {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerStats>().AddExperiance(giveExp);
            Destroy(gameObject);
            player.GetComponent<PlayerStats>().inCombat = false;
        }
    }

    public void DealDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
    }
}
