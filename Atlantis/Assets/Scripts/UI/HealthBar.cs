using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Transform Health_Bar;
    public Transform Health_Text;
    public GameObject Player;

    private float health;

    void Start () {
        health = Player.GetComponent<PlayerStats>().Health;
	}
	
	void Update () {
        health = Player.GetComponent<PlayerStats>().Health;
        if (health > 0)
        {
            Health_Text.GetComponent<Text>().text = ((int)health).ToString();
        }
        else {
            Health_Text.GetComponent<Text>().text = "0";
        }
        Health_Bar.GetComponent<Image>().fillAmount = health / 100;
    }
}
