using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private float timer;

    void Start()
    {
        timer = GameObject.Find("Player").GetComponent<PlayerStats>().cooldown;
    }
    void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().dealDamage == true) {
            gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().dealDamage = false;
            float damage = GameObject.Find("Player").GetComponent<PlayerStats>().damage;
            other.GetComponent<EnemyStats>().DealDamage(damage);
            timer = GameObject.Find("Player").GetComponent<PlayerStats>().cooldown;
            
        }
    }

}
