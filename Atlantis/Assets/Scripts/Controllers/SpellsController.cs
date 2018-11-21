using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsController : MonoBehaviour {

    private float damage;
    private bool spellOneCooldown = false;

    void Update()
    {
        if (Input.GetButtonDown("1") && spellOneCooldown == false) {
            gameObject.GetComponent<PlayerStats>().spellOneActive = true;
            damage = gameObject.GetComponent<PlayerStats>().damage;
            gameObject.GetComponent<PlayerStats>().damage += gameObject.GetComponent<PlayerStats>().damage * 0.5f;
            spellOneCooldown = true;
            StartCoroutine(SpellOneCooldown());

        }
    }

    IEnumerator SpellOneCooldown() {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<PlayerStats>().spellOneActive = false;
        gameObject.GetComponent<PlayerStats>().damage = damage;
        yield return new WaitForSeconds(3f);
        spellOneCooldown = false;

    }

}
