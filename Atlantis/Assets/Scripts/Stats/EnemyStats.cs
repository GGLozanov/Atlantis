using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

    public float health = 100f;
    public float damage = 5f;
    public float lookRadius = 10f;
    public float cooldown = 2f;

    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public void DealDamage(float damage) {
        if (health > 0)
        {
            health -= damage;
        }
    }
}
