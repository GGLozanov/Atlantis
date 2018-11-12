using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float Health = 100f;
    public float damage = 20f;
    public float cooldown = 1f;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Health <= 0) {
            Health = 0;
        }
	}

    public void DealDamage(float damageAmount) {
        if (Health > 0)
        {
            Health = Health - damageAmount;
        }
    }
}
